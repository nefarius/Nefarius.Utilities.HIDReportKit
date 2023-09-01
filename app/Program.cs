using HidSharp;

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

Memory<byte> buffer = new byte[ds.GetMaxInputReportLength()];
DualSenseInputReport report = InputReportFactory.CreateDualSenseInputReport();

while (true)
{
    stream.Read(buffer.Span);
    report.Parse(buffer[1..]);

    if (report.Cross)
    {
        Console.WriteLine("Cross pressed");
    }
}