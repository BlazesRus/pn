set PYTHONHOME=p:\WinPython-32bit-3.4.3.7\python-3.4.3
set path=%PYTHONHOME%;%path%;P:\bin\Far30b4131.x86.20141012
set PyPnPythonExe=%PYTHONHOME%\python.exe
set PNWinmergecmd=D:\Program Files (x86)\WinMerge\WinMergeU.exe
set PYTHONPATH=p:\Projects\git\portable\PyLibrary


"%PyPnPythonExe%" %~dp0scripts\fixusersettings.py "%~dp0settings\config.xml"
pn.exe --findexts
start pn.exe
pause

