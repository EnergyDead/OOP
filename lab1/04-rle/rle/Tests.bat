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

REM Successfully pack file
%MyProgram% "pack" "%~dp1correctInput_pack_1" "%~dp1output_pack_1" || goto err
fc "%~dp1output_pack_1" "%~dp1correctOutput_pack_1" || goto err
echo Test 2 passed

REM Successfully unpack file
%MyProgram% "unpack" "%~dp1correctInput_unpack_1" "%~dp1output_unpack_1" || goto err
fc "%~dp1output_unpack_1" "%~dp1correctOutput_unpack_1" || goto err
echo Test 3 passed

REM If argument has not 3 argument, program must fail
%MyProgram% "%~dp0first_0.txt"  && goto err
echo Test 4 passed

REM If argument has not correct params, program must fail
%MyProgram%  "error" "%~dp1correctInput_pack_1" "%~dp1output_pack_1" && goto err
echo Test 5 passed

REM If input file has 0 size, successfully
%MyProgram%  "pack" "%~dp1correctInput_zeroSize" "%~dp1output_zeroSize" || goto err 
fc "%~dp1output_zeroSize" "%~dp1correctOutput_zeroSize" || goto err
echo Test 6 passed

REM If input file has 0 size, successfully
%MyProgram%  "unpack" "%~dp1correctInput_zeroSize" "%~dp1output_zeroSize" || goto err 
fc "%~dp1output_zeroSize" "%~dp1correctOutput_zeroSize" || goto err
echo Test 7 passed

REM If input file has 1000 replace byte, successfully
%MyProgram%  "pack" "%~dp1input_1000_replaceByte" "%~dp1output_1000_replaceByte" || goto err 
fc "%~dp1output_1000_replaceByte" "%~dp1correctOutput_1000_replaceByte" || goto err
echo Test 8 passed

REM All tests passed successfully
echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1