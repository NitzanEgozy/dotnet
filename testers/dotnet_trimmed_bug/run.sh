#!/bin/bash

set -exuo pipefail

TARGET_EXE="$PWD/ILSpyInconsistentExe/bin/Debug/ILSpyInconsistentExe.exe"
OUTPUT_TRIMMED="$PWD/ILSpyInconsistentExe/decompile_output_trimmed"
OUTPUT_NON_TRIMMED="$PWD/ILSpyInconsistentExe/decompile_output_nontrimmed"
ILSPYCMD="$PWD/ILSpy-5.0.1_modified/ICSharpCode.Decompiler.Console/bin/Release/netcoreapp3.1/linux-x64/publish/ilspycmd"

rm -rf $OUTPUT_TRIMMED
rm -rf $OUTPUT_NON_TRIMMED 
mkdir $OUTPUT_TRIMMED
mkdir $OUTPUT_NON_TRIMMED

cd ILSpy-5.0.1_modified/ICSharpCode.Decompiler.Console

find . -iname "obj" | xargs rm -rf
find . -iname "bin" | xargs rm -rf

dotnet publish -f netcoreapp3.1 -r linux-x64 -c Release /p:PublishSingleFile=true /p:PackAsTool=false
$ILSPYCMD $TARGET_EXE -o $OUTPUT_NON_TRIMMED -p

find . -iname "obj" | xargs rm -rf
find . -iname "bin" | xargs rm -rf

dotnet publish -f netcoreapp3.1 -r linux-x64 -c Release /p:PublishSingleFile=true /p:PackAsTool=false /p:PublishTrimmed=true
$ILSPYCMD $TARGET_EXE -o $OUTPUT_TRIMMED -p
