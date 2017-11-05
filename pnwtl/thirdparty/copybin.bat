set bindir=%~1
set outdir=%~2
echo bindir:%bindir%
echo outdir:%outdir%

for %%f in (
        clips
        ctags
        presets
        schemes
        scripts
        projects
       ) do (
       echo copying %%f...
mkdir %outdir%\%%f
xcopy /y/d %bindir%\%%f\*.* %outdir%\%%f
       )


xcopy /y/d %bindir%\*.dll %outdir%
xcopy /y/d %bindir%\*.bat %outdir%

