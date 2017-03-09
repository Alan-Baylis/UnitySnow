git add --all
set /p str=comment:
git commit -a -m "%str% - %date% %time% by %USERNAME%"
git push
pause