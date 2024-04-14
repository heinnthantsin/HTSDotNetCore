using System.Data.SqlClient;
using System.Data;
using System.Text;


namespace HTSDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {


        private readonly SqlConnectionStringBuilder _sqlConnectionBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "nick", //server name
            InitialCatalog = "DotNetBatch4", // database name
            UserID = "sa",
            Password = "sasa@123"
        };
        public void Read()
        {   
            SqlConnection connection = new SqlConnection(_sqlConnectionBuilder.ConnectionString);

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
        }

        public void Create(String title,String author, String content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionBuilder.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[tbl_blog]
            [blogTitle]
           ,[blogAuthor]
           ,[blogContent]
     VALUES
           (@blogTitle,
			@blogAuthor,
			@blogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blogTitle", title);
            cmd.Parameters.AddWithValue("@blogAuthor", author);
            cmd.Parameters.AddWithValue("@blogcontent", content);
            int result = cmd.ExecuteNonQuery();

            string msg = result > 0 ? "Blog created" : "Creation Failed";
            Console.WriteLine(msg);
            connection.Close();
        }

        public void Update(int id,String title,String author,String content)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"UPDATE [dbo].[tbl_blog]
     SET [blogTitle] = @blogTitle
        ,[blogAuthor] = @blogAuthor
        ,[blogContent] = @blogContent
     WHERE [blogId] = @blogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@blogId", id);
            cmd.Parameters.AddWithValue("@blogTitle", title);
            cmd.Parameters.AddWithValue("@blogAuthor", author);
            cmd.Parameters.AddWithValue("@blogContent", content);
            int result = cmd.ExecuteNonQuery();
            string msg = result > 0 ? $"BLogID -> {id} is Updated" : "Updatation Failed";
            Console.WriteLine(msg);
            sqlConnection.Close();
        }

        public void Edit(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionBuilder.ConnectionString);
            sqlConnection.Open();
            string query = "SELECT * FROM tbl_blog WHERE [blogId] = @blogId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@blogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            sqlConnection.Close();
            if(dt.Rows.Count == 0)
            {
                Console.WriteLine($"Data associated with id {id} is not found !");
                return;
            }
            
            DataRow dr = dt.Rows[0];
            Console.WriteLine("Blog ID =>" + dr["blogId"]);
            Console.WriteLine("Blog Author =>" + dr["blogAuthor"]);
            Console.WriteLine("Blog Title =>" + dr["blogTitle"]);
            Console.WriteLine("Blog Content =>" + dr["blogContent"]);

        }

        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"DELETE FROM [dbo].[tbl_blog]
      WHERE [blogId] = @blogId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@blogId", id);
            int result = cmd.ExecuteNonQuery();
            string msg = result > 0 ? $"BlogId {id} is deleted successfully..." : "Deletion Failed !";
            Console.WriteLine($"{result} => {msg}");
        }
    }
}
