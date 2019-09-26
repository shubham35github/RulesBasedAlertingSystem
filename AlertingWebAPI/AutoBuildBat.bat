@echo off
set "BAT_PATH=%~dp0"

@echo off
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsDevCmd.bat"

echo %BAT_PATH%
echo Executing batch file

devenv "%BAT_PATH%\AlertingApp.sln" /build Debug 
pause

set testPath="%BAT_PATH%\DataModelDataContextTests\bin\Debug\DataModelDataContextTests.dll"
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath="%BAT_PATH%\DataModelFileReaderTests\bin\Debug\DataModelFileReaderTests.dll"
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath="%BAT_PATH%\DataModelFileWriterTests\bin\Debug\DataModelFileWriterTests.dll"
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath="%BAT_PATH%\DefaultValidatorTests\bin\Debug\DefaultValidatorTests.dll"
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath="%BAT_PATH%\GenericRepositoryTests\bin\Debug\GenericRepositoryTests.dll"
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

pause

"%BAT_PATH%\Simian\bin\simian-2.5.10.exe" "%BAT_PATH%\**\*.cs"  

pause

start "" http://localhost:62455/swagger

pause
