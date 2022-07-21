using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracDay_WebAPI.Models;
using System.Security.Cryptography;

namespace PracDay_WebAPI.Services
{
    
    public class AccountService
    {
        public byte[] passwordsalt = new byte[0];
        public AccountService(){
         
        }

        public List<Account> GetAccounts()
        {
            return null;
        }

        public void AddAccount(Account account){
            using var db = new AccountContext();
            db.Account.Add(new Account{userId=Guid.NewGuid(),userName=account.userName,password=saltAndHash(account.password),salt=passwordsalt});
            db.SaveChanges();
            
        }
        private string saltAndHash(string password)  
        {  
            /* make a new byte array*/
            byte[] salt;
            /*generate salt*/
            RandomNumberGenerator.Create().GetBytes(salt=new byte[16]);
            /* hash and salt using PBKDF2 */
            var pbkdf2 =new Rfc2898DeriveBytes(password,salt,10000);
            //put string in a byte array
            byte[] hash =pbkdf2.GetBytes(20);
            passwordsalt=hash;
            byte[] hashBytes =new byte[36];

            Array.Copy(salt,0,hashBytes,0,16);
            Array.Copy(hash,0,hashBytes,16,20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;

        }
    }
}