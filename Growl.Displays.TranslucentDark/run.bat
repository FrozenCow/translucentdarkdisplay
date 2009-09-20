tskill growl

if not "%LOCALAPPDATA%" == "" goto HasLocalAppData
set LOCALAPPDATA=%USERPROFILE%\Local Settings\Application Data
:HasLocalAppData

set TDD=%LOCALAPPDATA%\Growl\2.0.0.0\Displays\Translucent Dark Display

rmdir /S /Q "%TDD%"
mkdir "%TDD%"
xcopy "bin\Debug\*.*" "%TDD%\"

C:
cd "C:\Program Files\Growl for Windows\"
start growl.exe
pause