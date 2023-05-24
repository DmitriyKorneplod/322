using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System;
using System.Diagnostics.Eventing.Reader;
using Dentistry.Models;
using Org.BouncyCastle.Asn1.X509.SigI;

namespace Dentistry.Pages
{
    public class AuthModel : BasePageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var form = HttpContext.Request.Form;
            // ���� email �/��� ������ �� �����������, �������� ��������� ��� ������ 400
            if (!form.ContainsKey("login") || !form.ContainsKey("password"))
            return BadRequest("����� �/��� ������ �� �����������");
 
            string login = form["login"];
            string password = form["password"];

            var db = new dadyContext();
            Administrato? administrato = db.Administratos.FirstOrDefault(p => p.Login == login && p.Password == password);
            if(administrato is null)return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name,administrato.Login) };
            // ������� ������ ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            // ��������� ������������������ ����
            SignIn(new ClaimsPrincipal(claimsIdentity),CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
       }
    }

}