module.exports = function(grunt) {

	"use strict";

	var madge = require("madge"),
		requireConfig = grunt.file.readJSON("require.config.json") || {};

	function DependencyChecker(p_config) {
		p_config = p_config || {};

		var list = [],
			appRoot = p_config.appRoot || "app/",
			root = (p_config.root || ".").replace(/([^\/])$/, "$1/"),
			exclude = p_config.exclude || "dist/*",
			madgeConfig = {
				format: "amd",
				exclude: exclude
			};

		this.getDependenciesFrom = function(file) {
			var path = root + file + ".js",
				tree = null;

			if (grunt.file.exists(path)) {
				return madge(path, madgeConfig).tree;
			}
			return null;
		};

		this.getAllDependenciesFrom = function(file) {
			var result = this.getDependenciesFrom(file);

			if (result != null && list.indexOf(file) < 0 ) {
				list.push(file);

				result[file.split("/").pop()].forEach(function(val) {
					this.getAllDependenciesFrom(val);
				}.bind(this));
			}

			return list;
		};

		this.getRelatedTo = function(module) {
			return madge(root, madgeConfig).depends(module);
		};

		this.getAllRelatedTo = function(module) {
			var ret = [];
			this.getRelatedTo(module).forEach(function(val) {
				ret.push(val);
				ret = ret.concat(this.getRelatedTo(val));
			}.bind(this));

			return ret.filter(function(val, i, arr){
				return arr.indexOf(val) === i;
			});
		};

		this.getAllAppRelatedTo = function(module) {
			return this.getAllRelatedTo(module)
				.filter(function(val, i, arr) {
					return val.match(new RegExp("^" + appRoot)) != null;
				})
				.map(function(val) {
					return val.replace(new RegExp("^" + appRoot), "");
				});
		};

		this.convertFileToModule = function(file) {
			return file.replace(/\.js$/, "").split(root).pop();
		};

		this.isFileApp = function(file) {
			file = file.replace(/\.js$/, "").split(root).pop();
			return !!file.match(new RegExp("^" + appRoot), "");
		};
	}

	grunt.config.set("requirejs", (function() {
		var config = (function() {
				var config = {
					options: requireConfig
				};

				config.options.onBuildRead = function(mod, path, content) {
					if (config.options.syncModules.indexOf(mod) > -1) {
						return "queue(function(){ " + content + "});";
					}
					return content;
				};
				return config;
			}()),
			excludeFromPages = new DependencyChecker({
				"root": config.options.baseUrl,
				"appRoot": config.options.appFolder
			}).getAllDependenciesFrom(requireConfig.structureApp);

		grunt.file.recurse(config.options.baseUrl + "/" + config.options.appFolder, function(abs, root, sub, file){
			if (file.match(/\.js$/i)) {
				var name = file.replace(/\.js/i, ""),
					module = config.options.appFolder + name;

				config[name] = {
					"options": {
						"name": module,
						"exclude": name === "structure" ? [] : excludeFromPages,
						"out": config.options.baseUrl + "/" + config.options.outputFolder + file
					}
				};
			}
		});

		return config;
	}()));

	grunt.task.registerTask("requirejs_partial", "Run requirejs based on sub-module file.", function(file) {

		var dependencyChecker = new DependencyChecker({
				"root": requireConfig.baseUrl,
				"appRoot": requireConfig.appFolder
			}),
			appList = [],
			module,
			excludedFromPages = new DependencyChecker({
				"root": requireConfig.baseUrl,
				"appRoot": requireConfig.appFolder
			}).getAllDependenciesFrom(requireConfig.structureApp);

		file = file || grunt.config("requirejs_partial.file");
		module = dependencyChecker.convertFileToModule(file);
		module = module.replace(requireConfig.appFolder, "");

		if (excludedFromPages.indexOf(module) >= 0) {
			appList = ["requirejs:" + requireConfig.structureApp.replace(requireConfig.appFolder, "")];
		} else {
			appList = dependencyChecker
				.getAllAppRelatedTo(module)
				.map(function (val) {
					return "requirejs:" + val;
				});
		}

		if (appList.length === 0 && dependencyChecker.isFileApp(file)) {
			appList = ['requirejs:' + module];
		}

		grunt.task.run(appList);
		return appList;
	});

	grunt.event.on("watch", function(action, filepath, target) {
		if (target === "requirejs_partial") {
			grunt.config("requirejs_partial.file", filepath);
		}
	});

	grunt.config.set("uglify", {
		"main": {
			"options": {
				"sourceMap": false,
				"sourceMapIncludeSources": false,
				"sourceMapIn": function(source) {
					return source + ".map";
				},
				"preserveComments": false
			},
			"files": [{
				"expand": true,
				"cwd": "assets/js/dist",
				"src": ["**/*.js"],
				"dest": "assets/js/dist",
				"ext": ".js"
			}]
		}
	});

	grunt.config.set("jshint", {
		"options": {
			"jshintrc": "../.jshintrc"
		},
		"main": [
			"gruntfile.js",
			"assets/js/**/*.js",
			"!assets/js/dist/**/*.js"
		]
	});

	grunt.registerTask("js:dev",
		"Gera os javascripts no modo de 'desenvolvimento': não valida ou comprime;",
		["jshint", "requirejs"]);

	grunt.registerTask("js",
		"Gera os javascript no modo de 'produção', validando e executando o uglify;",
		["js:dev", "uglify"]);
};
