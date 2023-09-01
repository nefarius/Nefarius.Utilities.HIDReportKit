﻿using HidSharp;

using Nefarius.Utilities.HID.Devices.DualSense;
using Nefarius.Utilities.HID.Factories;

DeviceList? list = DeviceList.Local;

if (list is null)
{
    throw new InvalidOperationException();
}

IEnumerable<HidDevice>? dsDevices = list.GetHidDevices(0x054C, 0x0CE6);

if (dsDevices is null)
{
    throw new InvalidOperationException();
}

HidDevice ds = dsDevices.First();

HidStream? stream = ds.Open();

if (stream is null)
{
    throw new InvalidOperationException();
}

DualSenseInputReport report = InputReportFactory.CreateDualSenseInputReport();

#if NETFRAMEWORK
byte[] buffer = new byte[ds.GetMaxInputReportLength()];
#else
Span<byte> buffer = new byte[ds.GetMaxInputReportLength()];
#endif

while (true)
{
#if NETFRAMEWORK
    _ = stream.Read(buffer);
    report.Parse(buffer.Skip(1));
#else
    _ = stream.Read(buffer);
    report.Parse(buffer[1..]);
#endif

    if (report.Cross)
    {
        Console.WriteLine("Cross pressed");
    }
}