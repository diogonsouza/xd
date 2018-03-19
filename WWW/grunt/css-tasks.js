module.exports = function(grunt) {

	// "use strict";

	grunt.config.set("sass", {
		"dev": {
			"options": {
				"includePaths": [
					"bower_components"
				]
			},
			"files": [{
				"expand": true,
				"cwd": "assets/sass/output",
				"src": [
					"**/*.scss",
				].concat(grunt.option("guideline") === false ? ["!**/guideline-*.scss"] : []),
				"dest": "assets/css",
				"ext": ".css"
			}]
		},
		"dist": {
			"options": {
				"includePaths": [
					"bower_components"
				],
				"outputStyle": "compressed",
				"sourcemap": true
			},
			"files": [{
				"expand": true,
				"cwd": "assets/sass/output",
				"src": ["**/*.scss"],
				"dest": "assets/css",
				"ext": ".css"
			}]
		}
	});

	grunt.config.set("scsslint", {
		main: [
			"assets/sass/**/*.scss"
		],
		options: {
			bundleExec: true,
			colorizeOutput: true,
			config: "../.scss-lint.yml"
		}
	});

	grunt.registerTask("css:dev",
		"Gera os css no modo 'desenvolvimento': não valida ou comprime;",
		["scsslint", "sass:dev"]);

	grunt.registerTask("css",
		"Gera os css no modo de 'produção', validando e comprimindo;",
		["scsslint", "sass:dist"]);
};
