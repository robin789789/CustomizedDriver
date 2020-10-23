@echo off
@mode con lines=40 cols=75
color 02
title           Driver AutoInstall
echo.
echo           Auto Install...
echo.

c:
cd /Program Files (x86)/SSI_CustomizedDirver_Package
start /wait Elmo_Application_Studio_II/ElmoApplicationStudio.exe
