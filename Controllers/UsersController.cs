using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UsersWPI.Model;

namespace UsersWPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbcontext userDbcontext;
        public UsersController(UserDbcontext userDbcontext)
        {
            this.userDbcontext = userDbcontext;
        }

        [HttpGet]
        [Route("Getusers")]

        public List<Users>  GetUsers()
        {
            return userDbcontext.users.ToList();
           
            
        }
        [HttpGet]
        [Route("viewuser")]

        public Users GetOneUser(int id)
        {
            return userDbcontext.users.Where(x => x.id == id).FirstOrDefault();
        }


        [HttpPost]
        [Route("Postusers")]

        public string Addusers(Users user)
        {
            user.id = 0;
            string response = string.Empty;
            

           
                // Your code to save changes to the database
                userDbcontext.users.Add(user);

                userDbcontext.SaveChanges();
            return "User added";
          

            

        }
        [HttpPut]
        [Route("Updateusers")]

        public string putusers(Users user) 
        { 
            userDbcontext.Entry(user).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            userDbcontext.SaveChanges();
            return "user updated";
        }
        [HttpDelete]
        [Route("Deleteuser")]
        public string removeusers(int id)
        {
            Users user = userDbcontext.users.Where(a=>a.id==id).FirstOrDefault();
            if(user!=null)
            {
                userDbcontext.users.Remove(user);
                userDbcontext.SaveChanges();
                return "user deleted";
            }
            else
            {
                return "invalid";
            }
            
        }
      
        

    }
}
