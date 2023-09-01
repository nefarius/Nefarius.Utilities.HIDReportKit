using HidSharp;

using Nefarius.Utilities.HID.Devices.DualSense;

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

byte[] buffer = new byte[ds.GetMaxInputReportLength()];
DualSenseInputReport report = new DualSenseInputReport();

while (true)
{
    stream.Read(buffer);
    report.Parse(buffer.Skip(1).ToArray());

    if (report.Cross)
    {
        Console.WriteLine("Cross pressed");
    }
}