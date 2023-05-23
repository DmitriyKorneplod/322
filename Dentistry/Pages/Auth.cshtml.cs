using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System;
using System.Diagnostics.Eventing.Reader;
using Dentistry.Models;

namespace Dentistry.Pages
{
    public class AuthModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var form = Request.Form;
            // если email и/или пароль не установлены, посылаем статусный код ошибки 400
            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
            return BadRequest("Email и/или пароль не установлены");
 
            string login = form["login"];
            string password = form["password"];

            var db = new dadyContext();
            Administrato? administarto = db.Administratos.FirstOrDefault(p => p.login == login && p.password);
            if(administarto is null)return Unauthorized();
 
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, ) };
            // создаем объект ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            // установка аутентификационных куки
            SignIn(new ClaimsPrincipal(claimsIdentity),CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
       }
    }

}