@echo on

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

REM If non arguments, program must fail
%MyProgram% && goto err
echo Test 1 passed

REM Correct input, Successfully drow
%MyProgram% "%~dp0input_1.txt" "%~dp0output_1.txt"  || goto err
fc "%~dp0output_1.txt" "%~dp0correct_1.txt" || goto err
echo Test 2 passed

REM Correct input, Successfully drow
%MyProgram% "%~dp0input_2.txt" "%~dp0output_2.txt"  || goto err
fc "%~dp0output_2.txt" "%~dp0correct_2.txt" || goto err
echo Test 3 passed

REM Correct input, Successfully drow
%MyProgram% "%~dp0input_3.txt" "%~dp0output_3.txt"  || goto err
fc "%~dp0output_3.txt" "%~dp0correct_3.txt" || goto err
echo Test 4 passed

REM Has 'O' in outside, Successfully drow
%MyProgram% "%~dp0input_4.txt" "%~dp0output_4.txt"  || goto err
fc "%~dp0output_4.txt" "%~dp0correct_4.txt" || goto err
echo Test 5 passed

REM If argument not secoed file, program must fail
%MyProgram% "%~dp0input0.txt" && goto err
echo Test 6 passed


REM All tests passed successfully
echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1