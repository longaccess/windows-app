set TIMESTAMP=http://www.startssl.com/timestamp
set NAME="LONG ACCESS"
set VERSION=%1
set PLATFORM=%2
set RELEASE=%3
set NSIS=%4
set LACLI=..\packages\lacli.%VERSION%\lacli
call makensis /DVERSION=%VERSION% /DLACLI=%LACLI% /DPLATFORM=%PLATFORM% /DSIGN=%NAME% /DTIMESTAMP=%TIMESTAMP% /DRELEASE=%RELEASE% /V4 %NSIS%
call signtool sign /a /n %NAME% /tr %TIMESTAMP% Longaccess-%VERSION%-%PLATFORM%.exe