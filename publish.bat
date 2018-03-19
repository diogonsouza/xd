@ECHO OFF

::::::::::::::::::::::
:: Diretório do IIS ::
::::::::::::::::::::::
:: coloque o caminho do diretório de compilação no lugar do "0" sem o "\" do final
SET PUBLISH_DIR=0

goto comeca

::
:: verifica parâmetros
::
set PARAMS=%*

:: seta a variável "release" como 1 ou 0
call :hasParam release

:alerta
echo Antes de usar a opção release configure a variavel PUBLISH_DIR
echo com o caminho para o diretorio do IIS da aplicacao.
echo.
echo O arquivo se encontra no comeco do arquivo.
echo.
echo Ex: SET PUBLISH_DIR=C:\inetpub\wwwroot\projeto\www
echo.
goto sai

::
:: começa a brincadeira
:: 
:comeca
path=%PATH%;c:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\

if exist MSBuildTargets.exe MSBuildTargets

msbuild WWW.sln
if errorlevel 1 goto :errors

::
:: cria lista de arquivos para excluir na versão "release"
::

if [%release%] equ [1] (
	::
	:: se diretório não estiver personalizado, joga mensagem na tela
	::
	if %PUBLISH_DIR%==0 goto :alerta

	dir /s /b *.vb > exclude.txt 2> nul
	dir /s /b obj\ >> exclude.txt 2> nul
	dir /s /b *.cs >> exclude.txt 2> nul
	dir /s /b *.template >> exclude.txt 2> nul
	dir /s /b exclude.txt >> exclude.txt 2> nul
	dir /s /b *.bat >> exclude.txt 2> nul
	dir /s /b *.sln >> exclude.txt 2> nul
	dir /s /b *.svn >> exclude.txt 2> nul
	dir /s /b *_svn >> exclude.txt 2> nul
	dir /s /b *.csproj >> exclude.txt 2> nul
	dir /s /b *.vbproj >> exclude.txt 2> nul
	dir /s /b *.pdb >> exclude.txt 2> nul
	dir /s /b Web.Debug.config >> exclude.txt 2> nul
	dir /s /b Web.Release.config >> exclude.txt 2> nul
	aspnet_compiler -v %PUBLISH_DIR% -p %PUBLISH_DIR%

	echo Copiando arquivos de "%PUBLISH_DIR%\" para "publish\"
	xcopy "%PUBLISH_DIR%" "publish\" /exclude:exclude.txt /s /Y > nul 2> nul
	xcopy "%PUBLISH_DIR%\App_Code\*.cs" "publish\App_Code\" /s /Y > nul 2> nul
)

goto sai

:errors
echo -----------------------------
echo Publish Falhou. Erros acima.
echo -----------------------------  
echo Verifique se o Microsoft Visual Studio Shell 2010 está instalado.
echo -----------------------------  
echo http://www.microsoft.com/en-us/download/details.aspx?id=1366 
pause

:sai
if exist exclude.txt del exclude.txt > nul

:::::::::::::::::::::::::::::::::::::::::::::::::::
:: FUNCTIONS
:::::::::::::::::::::::::::::::::::::::::::::::::::

goto :EOF
:::::::::::::::::::::::::::::::::::::::::::::::::::
:hasParam
	if [%PARAMS%] equ [] set PARAMS= 
	set arg1=%1
	set arg2=%2
	call set param=%%PARAMS:*-%arg1%=1%%
	set param=%param: =&rem.%
	if [%arg2%] equ [] set arg2=%1
	if [%param%] equ [1] ( set "%arg2%=1" ) else ( set "%arg2%=0" )
goto :EOF
:::::::::::::::::::::::::::::::::::::::::::::::::::