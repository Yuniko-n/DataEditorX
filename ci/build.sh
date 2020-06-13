#!/bin/bash
set -x
set -o errexit
DEX_VERSION=$(grep -oP '\[DataEditorX\](.+)\[DataEditorX\]' DataEditorX/readme.txt | sed 's/\[DataEditorX\]//g')

# apt packages
sed -i '/download.mono-project.com/d' /etc/apt/sources.list /etc/apt/sources.list.d/*
apt update
apt -y install wget p7zip-full

# data files
wget -O DataEditorX/data/constant.lua https://koishi.pro/ygopro/script/constant.lua
wget -O DataEditorX/data/strings.conf https://koishi.pro/ygopro/strings.conf

# build
nuget restore
msbuild /p:Configuration=Release /p:Platform="Any CPU" /p:OutDir=$PWD/output/ /p:TargetFrameworkVersion=v4.6

# zip
mkdir -p dist/releases
cd output
7z a -mx9 ../dist/releases/DataEditorX-$DEX_VERSION.zip ./*
cd ..
cp -rf DataEditorX/readme.txt dist/version.txt
