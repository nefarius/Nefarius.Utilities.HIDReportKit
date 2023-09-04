<img src="assets/logo-128x128.png" align="right" />

# Nefarius.Utilities.HIDReportKit

[![.NET](https://github.com/nefarius/Nefarius.Utilities.HIDReportKit/actions/workflows/build.yml/badge.svg)](https://github.com/nefarius/Nefarius.Utilities.HIDReportKit/actions/workflows/build.yml) ![Requirements](https://img.shields.io/badge/Requires-.NET%20Standard%202.0-blue.svg) ![Requirements](https://img.shields.io/badge/Requires-.NET%206-blue.svg) [![Nuget](https://img.shields.io/nuget/v/Nefarius.Utilities.HIDReportKit)](https://www.nuget.org/packages/Nefarius.Utilities.HIDReportKit/) [![Nuget](https://img.shields.io/nuget/dt/Nefarius.Utilities.HIDReportKit)](https://www.nuget.org/packages/Nefarius.Utilities.HIDReportKit/)

Managed types and utility classes for HID report parsing and transforming.

Work in progress, use with care 🔥

## Motivation

How many utilities are floating out there either reading or transforming data from gaming input devices? HID Report reading/parsing is a common task for those and doing this by hand is tedious and prone to errors. Why not have a nice small class library you could consume and be done with it? Look no further, weary traveler, we've got you covered!    

## Goals

- **Compatibility**  
  Still on .NET Framework 4.8? No problem, we will not force you to upgrade for the core feature set, but you'll miss out on some awesome stuff .NET 6 and higher has to offer 😉  
- **Performance**  
  We'll do our absolute best to avoid unnecessary copy actions or other expensive operations that could taint your report parsing experience 💪 Spans much?
- **Plausibility**  
  Juggling opaque byte arrays will sooner or later lead to errors, how about some validation helpers and plausibility checks before you send a report on its way? 👌
- **Abstraction**  
  You are not in the mood to figure out what each darn byte in the controller state means? Can't blame you, to some it might look as close to magic as it can get. Was this value big- or little-endian? Don't know, don't care. We provide high-level abstractions you can consume in two lines and be done with it, no in-depth knowledge about bit-shifting or nibbles required 🔥

## Supported devices

- Sony™ DualShock™ 4 (PS4 Controller)
- Sony™ DualSense™ (PS5 Controller)
- ...more to come as the library grows! 

## NuGet

Until the library has reached level of maturity it won't be published on nuget.org, you can find [development builds on my private feed though](https://baget.nefarius.at/packages/nefarius.utilities.hidreportkit/) 👌 Use at your own risk, no support provided whatsoever.

## Sources & 3rd party credits

This application benefits from these awesome projects ❤ (appearance in no special order):

- [DS4Windows/Vapour Input](https://github.com/CircumSpector/DS4Windows)
- [Game Controller Collective Wiki - Sony DualSense](https://controllers.fandom.com/wiki/Sony_DualSense)
- [Game Controller Collective Wiki - Sony DualShock 4](https://controllers.fandom.com/wiki/Sony_DualShock_4)
- [Ryochan7/DS4Windows](https://github.com/Ryochan7/DS4Windows)
- [CRC32 algorithm implementation by Yuri Babich, Stephan Brumme & Bulat Ziganshin](https://github.com/yubabich/FastCRC)
- [JoyShockLibrary](https://github.com/JibbSmart/JoyShockLibrary)
- [Generator.Equals](https://github.com/diegofrata/Generator.Equals)
