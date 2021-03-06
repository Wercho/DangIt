﻿@echo off

copy /Y "bin\Release\DangIt.dll" "..\..\GameData\DangIt\Plugins"

rem copy /Y "bin\Debug\DangIt.dll" "..\..\GameData\DangIt\Plugins"

copy /Y ..\DangIt.version ..\..\GameData\DangIt
copy /Y ..\..\..\MiniAVC.dll ..\..\GameData\DangIt

set RELEASEDIR=d:\Users\jbb\release
set ZIP="c:\Program Files\7-zip\7z.exe"


rem type ..\DangIt.version
rem set /p VERSION= "Enter version: "


cd ..
set VERSIONFILE=DangIt.version
rem The following requires the JQ program, available here: https://stedolan.github.io/jq/download/
c:\local\jq-win64  ".VERSION.MAJOR" %VERSIONFILE% >tmpfile
set /P major=<tmpfile

c:\local\jq-win64  ".VERSION.MINOR"  %VERSIONFILE% >tmpfile
set /P minor=<tmpfile

c:\local\jq-win64  ".VERSION.PATCH"  %VERSIONFILE% >tmpfile
set /P patch=<tmpfile

c:\local\jq-win64  ".VERSION.BUILD"  %VERSIONFILE% >tmpfile
set /P build=<tmpfile
del tmpfile
set VERSION=%major%.%minor%.%patch%
if "%build%" NEQ "0"  set VERSION=%VERSION%.%build%

type DangIt.version

echo Version:  %VERSION%

mkdir ..\GameData\DangIt\licenses
xcopy /y /s ..\licenses ..\GameData\DangIt

copy /Y ..\README.md ..\GameData\DangIt
 
cd ..

set FILE="%RELEASEDIR%\DangIt-%VERSION%.zip"
IF EXIST %FILE% del /F %FILE%
%ZIP% a -tzip %FILE% GameData

