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

REM If argument not number, program must fail
%MyProgram% word && goto err
echo Test 2 passed

REM If argument not in 0..255, program must fail
%MyProgram% -1 && goto err
echo Test 3 passed

REM If argument not in 0..255, program must fail
%MyProgram% 256 && goto err
echo Test 4 passed

REM output secsess
%MyProgram% 0 "%TEMP%\output.txt" || goto err
fc "%TEMP%\output.txt"  "%~dp0result_0.txt" || goto err
echo Test 5 passed

REM output secsess
%MyProgram% 6 "%TEMP%\output.txt" || goto err
fc "%TEMP%\output.txt"  "%~dp0result_6.txt" || goto err
echo Test 6 passed

REM output secsess
%MyProgram% 123 "%TEMP%\output.txt" || goto err
fc "%TEMP%\output.txt"  "%~dp0result_123.txt" || goto err
echo Test 7 passed

REM output secsess
%MyProgram% 255 "%TEMP%\output.txt" || goto err
fc "%TEMP%\output.txt"  "%~dp0result_255.txt" || goto err
echo Test 8 passed

REM All tests passed successfully
echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1