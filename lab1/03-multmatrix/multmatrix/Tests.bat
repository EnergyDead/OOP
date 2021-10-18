@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

REM If non send argument, program must fail
%MyProgram% && goto err
echo Test 1 passed

REM Successfully multyply matrices
%MyProgram% "%~dp0first_0.txt" "%~dp0second_0.txt" "%TEMP%\output.txt" || goto err
fc "%TEMP%\output.txt" "%~dp0result_0.txt" || goto err
echo Test 2 passed

REM Successfully multyply matrices
%MyProgram% "%~dp0first_1.txt" "%~dp0second_1.txt" "%TEMP%\output.txt" || goto err
fc "%TEMP%\output.txt" "%~dp0result_1.txt" || goto err
echo Test 3 passed

REM If argument not secoed file, program must fail
%MyProgram% "%~dp0first_0.txt"  && goto err
echo Test 4 passed

REM If argument not temp file, program must fail
%MyProgram% "%~dp0first_1.txt" "%~dp0second_1.txt" || goto err
echo Test 5 passed

REM All tests passed successfully
echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1