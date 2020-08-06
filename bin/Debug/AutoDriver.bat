@echo off
@mode con lines=40 cols=75
color 02
title           Driver AutoInstall
echo.
echo           Auto Install...
echo.

start /wait CCD/USBcam/drvInstaller.exe
