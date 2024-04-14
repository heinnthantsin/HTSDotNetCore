using HTSDotNetCore.ConsoleApp;

AdoDotNetExample adoDotNet = new AdoDotNetExample();
adoDotNet.Read();
adoDotNet.Create("abc", "def", "hij");

Console.ReadKey(true); 