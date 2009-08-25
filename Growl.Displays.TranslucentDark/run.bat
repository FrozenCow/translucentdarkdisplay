tskill growl

rmdir /S /Q "C:\Program Files\Growl for Windows\Displays\TranslucentDark"
mkdir "C:\Program Files\Growl for Windows\Displays\TranslucentDark"
xcopy "bin\Debug\*.*" "C:\Program Files\Growl for Windows\Displays\TranslucentDark\"

C:
cd "C:\Program Files\Growl for Windows\"
start growl.exe
pause