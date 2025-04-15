#!/bin/bash
# Lua 5.4 is required

# !! May need to be tweaked later

RELEASE=release
BIN=bin/release/net9.0/linux-x64
ASSETS=assets
rm -rf release/*
set -e
dotnet build --ucr -c Release -v diag
mkdir -p $RELEASE
cp $ASSETS -r $RELEASE/
cp $BIN -r $RELEASE/

# This step to remove potentially unneeded guff from release
rm -f $RELEASE/*.pdb
rm -f $RELEASE/*.json
lua54 manifest-tool.lua -maj 0 -min 0 -ptc 0 -stg ALPHA
cp manifest.json $RELEASE
echo "NeonDreams build is ready."