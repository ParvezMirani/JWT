using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace JWT.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        [HttpGet, Authorize]
        public IEnumerable<Book> Get()
        {
            var currentUser = HttpContext.User;
            int userAge = 0;
            var resultBookList = new Book[]
            {
            new Book { Author = "Ray Bradbury", Title = "Fahrenheit 451", AgeRestriction = false },
              new Book { Author = "Gabriel García Márquez", Title = "One Hundred years of Solitude", AgeRestriction = false },
              new Book { Author = "George Orwell", Title = "1984", AgeRestriction = false },
              new Book { Author = "Anals Nin", Title = "Delta of Venus", AgeRestriction = true }
           };
            
            if(currentUser.HasClaim(c=>c.Type== ClaimTypes.DateOfBirth))
            {
                DateTime birtDate = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.DateOfBirth).Value);
                userAge = DateTime.Today.Year - birtDate.Year;
            }
            if (userAge < 18)
            {
                resultBookList = resultBookList.Where(b => !b.AgeRestriction).ToArray();
            }
           return resultBookList;
        }
    }
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public bool AgeRestriction { get; set; }
    }
}