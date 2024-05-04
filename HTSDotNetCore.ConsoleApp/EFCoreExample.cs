using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTSDotNetCore.ConsoleApp
{
    internal class EFCoreExample
    {   
        private readonly AppDBContext db = new AppDBContext();
        public void Run()
        {
            /*Edit(1);
            Edit(7);
            Create("mg mg", "HWLOE", "DJFLSDJFDJSFLFJLKDFJF");
            Update(2, "kg kg", "Something", "Iiiiiiii");*/
            Delete(10);
            Read();
        }

        private void Read()
        {
            var list = db.Blogs.ToList();
            foreach (var item in list)
            {
                Console.WriteLine("Blog Id => "+item.BlogId);
                Console.WriteLine("Blog Title => " + item.BlogTitle);
                Console.WriteLine("Blog Author => " + item.BlogAuthor);
                Console.WriteLine("Blog Content => " + item.BlogContent);
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(blog => blog.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            }
            Console.WriteLine("Blog Id => " + item.BlogId);
            Console.WriteLine("Blog Title => " + item.BlogTitle);
            Console.WriteLine("Blog Author => " + item.BlogAuthor);
            Console.WriteLine("Blog Content => " + item.BlogContent);
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("");
        }

        private void Create(String author,String title,String content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            var res = db.SaveChanges();
            String msg = res > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(msg);

        }

        private void Update(int id,String title, String content,String author) 
        {
            var item = db.Blogs.FirstOrDefault(b => b.BlogId == id);
            if(item is null) { Console.WriteLine("No Data Found!"); return; }

            item.BlogTitle = title;
            item.BlogAuthor = author;   
            item.BlogContent = content;
            int res = db.SaveChanges();
            String msg = res > 0 ? "Upadated Successfully..." : "Updatation Failed!";
            Console.WriteLine(msg);
        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(b => b.BlogId == id);
            if (item is null) { Console.WriteLine("No Data Found !"); return; }
            db.Blogs.Remove(item);
            int res = db.SaveChanges();
            String msg = res > 0 ? "Deleted Successsfully..." : "Deletion Failed";
            Console.WriteLine(msg);
        }
    }
}
