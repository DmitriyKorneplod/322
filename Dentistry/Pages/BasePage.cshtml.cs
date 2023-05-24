using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.AccessControl;
using System.Security.Claims;

namespace Dentistry.Pages
{
    public class BasePageModel : PageModel
    {
        public Staff? staff { get; set; }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Claim claim =HttpContext.Administrato.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null) 
            {
                string[] row=Convert.ToString(claim.Value).Split(" ");
                ViewData["Login"] = raw [1];
            }
            base.OnPageHandlerExecuting(context);
        }    
        
    }
}
