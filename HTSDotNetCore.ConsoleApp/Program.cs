using System.Data;
using System.Data.SqlClient;

Console.WriteLine("hello,world");

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "nick";
stringBuilder.InitialCatalog = "DotNetBatch4";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sasa@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

connection.Open();
string query = "SELECT * FROM tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);
connection.Close();

/*foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("blog_id" + dr[0]);
    Console.WriteLine("blog_id" + dr[1]);
    Console.WriteLine("blog_id" + dr[2]);
    Console.WriteLine("blog_id" + dr[3]);
    Console.WriteLine("---------------------");
}*/

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("blog_id" + dr["blogId"]);
    Console.WriteLine("blog_id" + dr["blogTitle"]);
    Console.WriteLine("blog_id" + dr["blogAuthor"]);
    Console.WriteLine("blog_id" + dr["blogContent"]);
    Console.WriteLine("---------------------");
}

Console.ReadKey(true); 