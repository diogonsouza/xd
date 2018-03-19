module.exports = function(grunt) {

	"use strict";

	require("jit-grunt")(grunt, {
		scsslint: "grunt-scss-lint"
	});

	if (grunt.option("verbose")) {
		require("time-grunt")(grunt);
	}

	grunt.config.set("paths", {
		project: (function() {
			var run = require('child_process').execSync,
				name = "hyojun.bootstrap";
			try {
				name = run('git remote -v 2> /dev/null').toString('utf8');
				name = (name.match(/\/(.[^\/]*)\.git/) || [name]).pop();
			} catch (e) {}

			return name;
		}()),
		rjs: {
			bower: "../../bower_components"
		}
	});

	grunt.config.set("watch", {
		requirejs_partial: {
			files: [
				"assets/**/*.js",
				"!assets/js/dist/**/*.js"
			],
			tasks: ["requirejs_partial", "exec:sync", "exec:touch"],
			options: {
				livereload: true,
				spawn: false
			}
		},
		sass: {
			files: ["assets/sass/**/*.scss", "exec:sync", "exec:touch"],
			tasks: ["sass:dev"]
		},
		noop: {
			options: {
				livereload: true
			},
			files: "noop.config"
		}
	});

	// tasks estão separadas no diretório grunt
	grunt.loadTasks("grunt");

	grunt.registerTask("lint",
		"Valida o projeto com jshint e scsslint;",
		["scsslint", "jshint"]);

	grunt.registerTask("default",
		"Task padrão gera o css e js no modo 'produção'.",
		["css", "js"]);
};
