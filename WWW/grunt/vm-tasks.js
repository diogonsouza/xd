module.exports = function(grunt) {

	"use strict";

	var connectionStringPath = "Config/connectionString.config",
		hasDB = grunt.file.exists(connectionStringPath);

	grunt.config.set("paths.rsync", "/Volumes/wwwroot/<%=paths.project %>");
	grunt.config.set("exec", {
		"npm": "npm install",
		"bower": "bower install -F",
		"bundle": "bundle install",
		"touch": "touch noop.config",
		"vm-mount": [
			'mkdir -p /Volumes/wwwroot/ &&',
			'if [ ! -f /Volumes/wwwroot/web.config ]; then',
			'mount_smbfs',
			'"//VAGRANT-PC;vagrant:vagrant@192.168.56.101/wwwroot"',
			'/Volumes/wwwroot/;',
			'fi'
		].join(" "),
		"vm-unmount": [
			'if [ -d /Volumes/wwwroot/ ]; then',
			'umount /Volumes/wwwroot/;',
			'fi'
		].join(" "),
		"vm-start": "vagrant up",
		"vm-stop": "vagrant suspend",
		"vm-shutdown": "vagrant halt",
		"vm-app": {
			cmd: [
				'vagrant ssh --',
				'\'cmd /c',
				'inetsrv\\appcmd.exe add APP',
				'/site.name:"Default Web Site"',
				'/path:"/<%=paths.project%>"',
				'/physicalPath:"c:\\inetpub\\wwwroot\\<%=paths.project%>\\www"\''
			].join(" "),
			exitCode: [0, 183]
		},
		"vm-build": [
			"vagrant ssh --",
			"'cmd /c",
			"\"cd c:\\inetpub\\wwwroot\\<%=paths.project%> && publish.bat\"'"
		].join(" "),
		"vm-sql": [
			'vagrant ssh --',
			'"cmd /c',
			'\\"\\"C:\\Program Files\\Microsoft SQL Server\\100\\Tools\\Binn\\SQLCMD.EXE\\"',
			'-S .\\SQLEXPRESS -U sa -P 1qazZAQ! -Q \\"CREATE DATABASE [<%=paths.project%>]\\" -t 0\\""'
		].join(" "),
		"sync": [
			"rsync",
			"-rvuzW",
			"--delete",
			"--exclude-from=../.rsync-ignore",
			"../",
			"<%=paths.rsync%>"
		].join(" "),
		"sync-all": [
			"rsync",
			"-rvzW",
			"--delete",
			"--exclude-from=../.rsync-ignore",
			"../",
			"<%=paths.rsync%>"
		].join(" ")
	});

	grunt.config.set('watch.sync',{
		files: [
			"assets/css/**/*.css",
			"**/*.config",
			"assets/js/dist/**/*.js",
			"assets/img/**/*.*",
			"assets/fonts/**/*.*",
			"Views/**/*.*",
			"App_Code/**/*.*",
			"!noop.config"
		],
		tasks: ["sync", "exec:touch"]
	});

	grunt.registerTask("update-connection-string",
		"atualiza a connection string com as credenciais da máquina virtual",
		function() {
			grunt.file.preserveBOM = true;
			var content = grunt.file.read(connectionStringPath)
				.replace(/(Data Source=)(.*?);/, '$1\.\\SQLExpress;')
				.replace(/(Initial Catalog=)(.*?);/, '$1' + grunt.config('paths.project') + ';')
				.replace(/(User Id=)(.*?);/, '$1sa;')
				.replace(/(Password=)(.*?);/, '$11qazZAQ!;');
			grunt.file.write(connectionStringPath, content);
		});

	grunt.registerTask("sync",
		"Sincroniza apenas os arquivos modificados para a máquina virtual;",
		["exec:sync"]);

	grunt.registerTask("sync:all",
		"Envia todos os arquivos do projeto para a máquina virtual;",
		["exec:sync-all"]);

	grunt.registerTask("setup",
		"Faz o startup da máquina, deixando-a disponível em localhost:1144/" + grunt.config("paths.project") + ";",
		[
			"githooks", "exec:bower", "exec:bundle",
			"exec:vm-start", "exec:vm-mount", "exec:vm-app"
		]
		.concat(hasDB ? ["exec:vm-sql", "update-connection-string"] : [])
		.concat(["sync", "exec:vm-build"]));

	grunt.registerTask("start-vm",
		"Inicia a máquina virtual e monta o drive;",
		["exec:vm-start", "exec:vm-mount"]);

	grunt.registerTask("stop-vm",
		"Desliga a máquina virtual e desmonta o drive;",
		["exec:vm-unmount", "exec:vm-stop"]);

	grunt.registerTask("shutdown-vm",
		"Desliga a máquina virtual e desmonta o drive;",
		["exec:vm-unmount", "exec:vm-shutdown"]);

	grunt.registerTask("mount",
		"Monta o drive da VM para que o `grunt sync` funcione corretamente;",
		["exec:vm-mount"]);

	grunt.registerTask("build",
		"Compila o projeto .NET na máquina virtual;",
		["exec:vm-build"]);

	grunt.registerTask("packages",
		"Instala os pacotes necessários para rodar o projeto;",
		["exec:npm", "exec:bower", "exec:bundle"]);
};
