using HTSDotNetCore.ConsoleApp;



//Ado DotNet Example
//AdoDotNetExample adoDotNet = new AdoDotNetExample();
//adoDotNet.Read();
//adoDotNet.Create("Create Testiing new", "Author Testing new", "Content Testing new");
/*adoDotNet.Update(2, "Testing","Testing", "Testing");
adoDotNet.Edit(3);
adoDotNet.Delete(7);*/


//Dapper Example

DapperExample dapperExample = new DapperExample();  
dapperExample.Run();
Console.ReadKey(true); 