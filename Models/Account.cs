using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracDay_WebAPI.Models
{
    public class AccountContext : DbContext
    {


    public DbSet<Account> Account { get; set; }

     public string DbPath { get; }

       /* public AccountContext(string dbPath) 
        {
            this.DbPath = dbPath;
   
        }*/
            
    public AccountContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        //DbPath = System.IO.Path.Join(path, "accounts.db");
        DbPath="accounts.db";

    }


    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Account
    {
        [Key]
         public Guid userId {get; set;}
         public string userName {get; set;}

         public string password {get; set;}

         public byte[] salt {get; set;}

    }
}