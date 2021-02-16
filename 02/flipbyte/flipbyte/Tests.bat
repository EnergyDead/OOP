@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)
exit /B 0
REM If non send argument, program must fail
%MyProgram%  && goto err
echo Test 1 passed

REM If argument not number, program must fail
%MyProgram% word && goto err
echo Test 2 passed

REM All tests passed successfully
echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1