using HTSDotNetCore.ConsoleApp;

AdoDotNetExample adoDotNet = new AdoDotNetExample();
adoDotNet.Read();
adoDotNet.Create("Create Testiing", "Author Testing", "Content Testing");
adoDotNet.Update(2, "Testing","Testing", "Testing");
adoDotNet.Edit(3);
adoDotNet.Delete(7);

Console.ReadKey(true); 