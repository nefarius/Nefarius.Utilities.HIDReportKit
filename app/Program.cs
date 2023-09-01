using HidSharp;

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

var buffer = new byte[ds.GetMaxInputReportLength()];

while (true)
{
    stream.Read(buffer);
}
