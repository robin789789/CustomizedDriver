@echo off
@mode con lines=40 cols=75
color 02
title           Driver AutoInstall
echo.
echo           Auto Install...
echo.

start  Mitsubishi/SN.txt
start /wait Mitsubishi/MitsubishiEN/setup.exe
start /wait Mitsubishi/MRConfiguratorSC/setup.exe
start /wait ElmoComposer/ElmoComposerSetup.exe
start /wait Elmo_Application_Studio_II/ElmoApplicationStudio.exe
start /wait Moons/STConfigurator.exe
start /wait Keyence/3000/setup.exe
start /wait MettlerToledo/APW-LinkSetup_V2.6.0.exe
start /wait CCD/Gigecam/gigecam.exe
