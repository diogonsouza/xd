# Hyojun.bootstrap

`versão 3.6.0`

Bootstrap para projetos ASP.NET MVC utilizados pela F.biz.

## Setup

Instale os seguintes programas:

1. [Ruby](http://www.ruby-lang.org/pt/downloads/) — `2.0+`;
2. [Vagrant](https://www.vagrantup.com/downloads.html) — `1.7.3+`;
3. [Virtual Box 4](https://www.virtualbox.org/wiki/Download_Old_Builds_4_3) — `4.3.30`;
3. [NodeJS](http://nodejs.org) — `0.12+`;
4. Bundler — `gem install bundler`;
5. Bower — `npm install -g bower`;
6. GruntCLI — `npm install -g grunt-cli`;

Clone o projeto e rode as tarefas:

    $ git clone git@bitbucket.org:fbiz/hyojun.bootstrap.git
    $ cd hyojun.bootstrap/WWW && npm install && grunt setup

Quando a máquina virtual estiver pronta, o servidor estará disponível em http://localhost:1144/hyojun.bootstrap

Veja a documentação completa na [wiki](https://bitbucket.org/fbiz/hyojun.bootstrap/wiki/Home).

Veja a documentação do Core de back-end em [hyojun.bootstrap-core](https://bitbucket.org/fbiz/hyojun.bootstrap-core/)

## Como contribuir

Participe das conversas no slack e na lista de issues: discuta, abra, investigue ou resolva issues. Existem diversas melhorias a serem feitas! :)

Antes de começar a produzir, veja se não há outra pessoa trabalhando na mesma coisa e fique por dentro dos milestones do projeto.

Faça um fork do projeto e [envie um pull-request](https://bitbucket.org/fbiz/hyojun.bootstrap/pull-request/new) para o branch `working`.

Utilizamos [semver](http://semver.org/) para versionar o projeto e abrimos uma tag no formato "major.minor.fix" para cada release público.

Canal do slack: https://fbiz.slack.com/messages/hyojun/
