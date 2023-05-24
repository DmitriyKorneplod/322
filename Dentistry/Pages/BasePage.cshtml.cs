using Dentistry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.AccessControl;
using System.Security.Claims;

namespace Dentistry.Pages
{
    public class BasePageModel : PageModel
    {
        public Client? client { get; set; }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            ViewData["SiteName"] = "УткинаСлюнка";
            Claim? claim = HttpContext.User.FindFirst(ClaimTypes.Name);
            if (claim != null) 
            {
                string[] row=Convert.ToString(claim.Value).Split(" ");
                ViewData["Login"] = row [1];
            }
            base.OnPageHandlerExecuting(context);
        }    
        
    }
}
