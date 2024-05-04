﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTSDotNetCore.ConsoleApp
{
    internal class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDto> Blogs { get; set; }
    }
}
