set ANT_HOME=P:\app\apache-ant-1.10.1
set ANT_CMD=%ANT_HOME%\bin\ant
cd /d  "%~dp0"
call "%ANT_CMD%" -f "%~dp0\build.xml"