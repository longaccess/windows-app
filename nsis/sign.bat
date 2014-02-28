set TIMESTAMP=http://www.startssl.com/timestamp
set NAME="LONG ACCESS"
set VERSION=%1
set PLATFORM=%2
set NSIS=%3
set LACLI=..\packages\lacli.%VERSION%\lacli
call makensis /DVERSION=%VERSION% /DLACLI=%LACLI% /DPLATFORM=%PLATFORM% /DSIGN=%NAME% /DTIMESTAMP=%TIMESTAMP% /V4 %NSIS%
call signtool sign /a /n %NAME% /tr %TIMESTAMP% Longaccess-%VERSION%-%PLATFORM%.exe