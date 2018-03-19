module.exports = function(grunt) {

	"use strict";

	grunt.config.set("githooks.all", {
		"options": {
			"dest": "../.git/hooks"
		},
		"pre-commit": "lint",
		"post-merge": "packages"
	});

};
