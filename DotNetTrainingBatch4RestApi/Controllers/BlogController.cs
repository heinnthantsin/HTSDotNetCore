using DotNetTrainingBatch4RestApi.Db;
using DotNetTrainingBatch4RestApi.Model;
using Microsoft.Data.SqlClient; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch4RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BlogController() { _context = new AppDbContext(); }

        [HttpGet]
        public IActionResult Read()
        {
            var list = _context.Blogs.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {  
            _context.Blogs.Add(blog);
            var res = _context.SaveChanges();
            String msg = res > 0 ? "Created Successfully....... " : "creation failed";
            return Ok(msg);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id,BlogModel blog) 
        {
            var item = _context.Blogs.FirstOrDefault(blog => blog.BlogId == id);
            if(item is null) { return NotFound("No Data Found!"); }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            var res  = _context.SaveChanges();
            String msg = res > 0 ? "Updated Successfully..." : "Updatation Failed!";
            return Ok(msg);

        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id) 
        {
            var item = _context.Blogs.FirstOrDefault(blog => blog.BlogId == id);
            if(item is null)
            {
                return NotFound("No data Found!");
            }
            return Ok(item);
        }   

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var item = _context.Blogs.FirstOrDefault(blog => blog.BlogId == id);
            if(item is null)
            {
                return NotFound("No data Found !");
            }
            _context.Blogs.Remove(item);
            var res = _context.SaveChanges();
            String msg = res > 0 ? "Deleted Successfully..." : "Deletion Failed!";

            return Ok(msg);


        }  
    }
}
