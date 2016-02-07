set PYTHONHOME=D:\portable\Portable_Python_3.2.5.1\App
set path=%PYTHONHOME%;%path%;P:\bin\Far30b4131.x86.20141012
set PyPnPythonExe=%PYTHONHOME%\python.exe
set PNWinmergecmd=D:\Program Files (x86)\WinMerge\WinMergeU.exe
set PYTHONPATH=D:\portable\Projects\git\portable\PyLibrary


"%PyPnPythonExe%" %~dp0scripts\fixusersettings.py "%~dp0settings\config.xml"
pn.exe --findexts
start pn.exe
pause

