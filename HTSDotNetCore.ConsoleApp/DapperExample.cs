using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace HTSDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run() {
           /* Create("Test Title Dapper", "Test Author Dapper", "Test Content Dapper");
            Edit(9);
            Update(5, "simTitle", "simAuthor", "simContent");*/
            Delete(5);
            Read();
        }

        private void Read()
        {
           using IDbConnection db = new SqlConnection(SqlConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
           List<BlogDto> list = db.Query<BlogDto>("select * from tbl_blog").ToList();

           foreach (BlogDto blog in list)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
                Console.WriteLine("==================");
                
            }
        }

        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(SqlConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select * from tbl_blog WHERE BlogId = @BlogId",new BlogDto{ BlogId = id }).FirstOrDefault();

           if(item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            }
            Console.WriteLine("Blog Id is => " + item.BlogId);
            Console.WriteLine("Blog Author is => " + item.BlogAuthor);
            Console.WriteLine("Blog Content is => " + item.BlogContent);
            Console.WriteLine("Blog Title is => " + item.BlogTitle);
        }

        private void Create(String title,String author, String content)
        {
            String query = @"INSERT INTO [dbo].[tbl_blog]
                            ([blogTitle],
                             [blogAuthor],
                             [blogContent])
                              VALUES
                             (@BlogTitle,
                              @BlogAuthor,
                              @BlogContent)";
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            using IDbConnection db = new SqlConnection(SqlConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query,item);

            String msg = result > 0 ? "Created Successfully..." : "Creation Failed!";
            Console.WriteLine(msg);
        }

        private void Update(int id,String author,String title,String content) 
        {
            String query = @"UPDATE [dbo].[tbl_blog] SET 
                                       [blogTitle] = @BlogTitle,
                                       [blogAuthor] = @BlogAuthor,
                                        [blogContent] = @BlogContent
                           WHERE [blogId] = @BlogId";


            var item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            using IDbConnection db = new SqlConnection(SqlConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            String msg = result > 0 ? "Updated Successfully..." : "Updation Failed!";
            Console.WriteLine(msg);
        }

        private void Delete(int id)
        {
            String query = @"DELETE FROM [dbo].[tbl_blog] WHERE [blogId] = @BlogId";
            var item = new BlogDto { BlogId = id };
            using IDbConnection db = new SqlConnection(SqlConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query,item);
            String msg = result > 0 ? "DELETED SUCCESSFULLY...." : "DELETION FAILED!";
            Console.WriteLine(msg);
        }
    }
}
