set ANT_HOME=P:\apache-ant-1.10.1
set ANT_CMD=P:\apache-ant-1.10.1\bin\ant
cd /d  "%~dp0"
call "%ANT_CMD%" -f "%~dp0\build.xml"
pause