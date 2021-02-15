@echo off

REM Path to test program transmitted through 1 argument
SET MyProgram="%~1"

REM protection against starting with no arguments
if %MyProgram%=="" (
	echo Please specify path to program
	exit /B 1
)

REM Search string in empty file, program must fail
%MyProgram% "%~dp0Empty.txt" hello && goto err
echo Test 1 passed

REM Search string in non empty file
%MyProgram% "%~dp0NonEmpty.txt" "project" || goto err
echo Test 2 passed

REM Search string in non empty file which does not contain search string
%MyProgram% "%~dp0NonEmpty.txt" hello && goto err
echo Test 3 passed

REM Search empty string in non empty file
%MyProgram%  "%~dp0NonEmpty.txt" || goto err
echo Test 4 passed

REM If file and string are not specified, program must fail
%MyProgram% && goto err
echo Test 5 passed

REM Search empty string in empty file
%MyProgram%  "%~dp0Empty.txt" || goto err
echo Test 6 passed

REM Search two string in file
%MyProgram%  "%~dp0Empty.txt" "ian \nwo" && goto err
echo Test 7 passed

REM All tests passed successfully
exit /B 0

REM If get an error
:err
echo Test failed
exit /B 1