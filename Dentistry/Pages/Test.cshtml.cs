using Dentistry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dentistry.Pages
{
    public class TestModel : PageModel
    {
        public List<Client> Clients { get; set; }
        public TestModel()
        {
            dadyContext dbContext =new dadyContext();
            Clients = dbContext.Clients.ToList();
        }
        public string GetString()
        {
            return "text";
        }
        public void OnGet()
        {
        }
    }
}
