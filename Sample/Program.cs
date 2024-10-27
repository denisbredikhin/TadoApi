// See https://aka.ms/new-console-template for more information

using KoenZomers.Tado.Api;

var session = new Session("denis.bredikhin@gmail.com", "");
await session.Authenticate();

var me = await session.GetMe();

Console.WriteLine(me.Homes[0].Name);

var rooms = await session.GetZones((int)me.Homes[0].Id);

foreach (var room in rooms) {
    Console.Write(room.Name+" - ");
    var tempOffset = await session.GetZoneTemperatureOffset(room);
    Console.WriteLine(tempOffset);
}

var devices = await session.GetDevices((int)me.Homes[0].Id);

foreach (var device in devices)
    Console.WriteLine(device.SerialNo);

Console.ReadLine();