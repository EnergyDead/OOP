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
%MyProgram% "pack" "%~dp0correctInput_pack_1" "%~dp0output_pack_1" || goto err
fc "%~dp0output_pack_1" "%~dp0correctOutput_pack_1" || goto err
echo Test 2 passed

REM Successfully unpack file
%MyProgram% "unpack" "%~dp0correctInput_unpack_1" "%~dp0output_unpack_1" || goto err
fc "%~dp0output_unpack_1" "%~dp0correctOutput_unpack_1" || goto err
echo Test 3 passed

REM If argument has not 3 argument, program must fail
%MyProgram% "%~dp0first_0.txt"  && goto err
echo Test 4 passed

REM If argument has not correct params, program must fail
%MyProgram%  "error" "%~dp0correctInput_pack_1" "%~dp0output_pack_1" && goto err
echo Test 5 passed

REM If input file has 0 size, successfully
%MyProgram%  "pack" "%~dp0correctInput_zeroSize" "%~dp0output_zeroSize" || goto err 
fc "%~dp0output_zeroSize" "%~dp0correctOutput_zeroSize" || goto err
echo Test 6 passed

REM If input file has 0 size, successfully
%MyProgram%  "unpack" "%~dp0correctInput_zeroSize" "%~dp0output_zeroSize" || goto err 
fc "%~dp0output_zeroSize" "%~dp0correctOutput_zeroSize" || goto err
echo Test 7 passed

REM If input file has 1000 replace byte, successfully
%MyProgram%  "pack" "%~dp0input_1000_replaceByte" "%~dp0output_1000_replaceByte" || goto err 
fc "%~dp0output_1000_replaceByte" "%~dp0correctOutput_1000_replaceByte" || goto err
echo Test 8 passed

REM input file has 2 byte 255, successfully pack
%MyProgram%  "pack" "%~dp0input_twoByte_255" "%~dp0output_twoByte_255" || goto err 
fc "%~dp0output_twoByte_255" "%~dp0correctOutput_twoByte_255" || goto err
echo Test 9 passed

REM input file has 2 byte 255, successfully unpack
%MyProgram%  "unpack" "%~dp0intput_twoByte_255_unpak" "%~dp0output_twoByte_255_unpak" || goto err 
fc "%~dp0output_twoByte_255_unpak" "%~dp0correctOutput_twoByte_255_unpak" || goto err
echo Test 10 passed

REM All tests passed successfully
echo All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1