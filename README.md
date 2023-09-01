<img src="assets/logo-128x128.png" align="right" />

# Nefarius.Utilities.HIDReportKit

[![.NET](https://github.com/nefarius/Nefarius.Utilities.HIDReportKit/actions/workflows/build.yml/badge.svg)](https://github.com/nefarius/Nefarius.Utilities.HIDReportKit/actions/workflows/build.yml)

## About

TBD

## Motivation

How many utilities are floating out there either reading or transforming data from gaming input devices? HID Report reading/parsing is a common task for those and doing this by hand is tedious and prone to errors. Why not have a nice small class library you could consume and be done with it? Look no further, weary traveler, we've got you covered!    

## Goals

- **Compatibility**  
  Still on .NET Framework 4.8? No problem, we will not force you to upgrade for the core feature set, but you'll miss out on some awesome stuff .NET 6 and higher has to offer 😉  
- **Performance**  
  We'll do our absolute best to avoid unnecessary copy actions or other expensive operations that could taint your report parsing experience 💪 Spans much?
- **Plausibility**  
  Juggling opaque byte arrays will sooner or later lead to errors, how about some validation helpers and plausibility checks before you send a report on its way? 👌

## Supported devices

- Sony DualShock 4 (PS4 Controller)
- Sony DualSense (PS5 Controller)

## Sources & 3rd party credits

This application benefits from these awesome projects ❤ (appearance in no special order):

- [DS4Windows/Vapour Input](https://github.com/CircumSpector/DS4Windows)
- [Game Controller Collective Wiki - Sony DualSense](https://controllers.fandom.com/wiki/Sony_DualSense)
- [Game Controller Collective Wiki - Sony DualShock 4](https://controllers.fandom.com/wiki/Sony_DualShock_4)
- [Ryochan7/DS4Windows](https://github.com/Ryochan7/DS4Windows)
- [CRC32 algorithm implementation by Yuri Babich, Stephan Brumme & Bulat Ziganshin](https://github.com/yubabich/FastCRC)
- [JoyShockLibrary](https://github.com/JibbSmart/JoyShockLibrary)
