cd /d "%~dp0"
rem @ECHO OFF
@del *.obj /s
@del *.pch /s
@del *.pdb /s
@del *.sbr /s
@del *.res /s
@del *.ilk /s
@Del *.idb /s 
@Del *.bsc /s
@Del *.log /s
@Del *.tlb /s
rd /s/q .vs

for /f "tokens=*" %%G in ('dir /b /s /a:d "Intermediate"') do (
rd /s/q "%%G"
)

for /f "tokens=*" %%G in ('dir /b /s /a:d "Release"') do (
rd /s/q "%%G"
)

for /f "tokens=*" %%G in ('dir /b /s /a:d "Debug"') do (
rd /s/q "%%G"
)

pause

