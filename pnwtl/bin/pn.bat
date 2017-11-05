set PYTHONHOME=P:\WinPython-32bit-3.6.2.0Zero\python-3.6.2
set path=%PYTHONHOME%;%path%;P:\bin\Far30b4131.x86.20141012
set PyPnPythonExe=%PYTHONHOME%\python.exe
set PNWinmergecmd=D:\Program Files (x86)\WinMerge\WinMergeU.exe
set PYTHONPATH=p:\Projects\git\portable\PyLibrary
set PYPN_INIT_PY_PATH=p:\Projects\git\portable\PyLibrary\pypn\init.py
"%PyPnPythonExe%" -m pyserg.pypn.fixusersettings "%~dp0settings\config.xml"  >> "%~dp0log.log" 2>&1

pn.exe --findexts
start pn.exe
pause

