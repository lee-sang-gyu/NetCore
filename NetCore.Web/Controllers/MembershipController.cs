using Microsoft.AspNetCore.Mvc;
using NetCore.Web.Models;
using NuGet.Protocol.Plugins;

namespace NetCore.Web.Controllers
{
    public class MembershipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]//ValidateAntiForgeryToken 전부 지정
        [ValidateAntiForgeryToken] //위조방지토큰을 통해 View로부터 받은 PostData가 유요한지 검증
        public IActionResult Login(LoginInfo login)
        {
            string message = string.Empty;
            //view모델 상태 체크
            if (ModelState.IsValid)
            {
                string userId = "ideal1";
                string password = "123456";
                if (login.UserId.Equals(userId) && login.Password.Equals(password))
                {
                    TempData["Message"] = "로그인이 성공적으로 이루어졌습니다.";
                    return RedirectToAction("Index", "Membership");

                }
                else 
                {
                    message = "로그인되지 않았습니다.";
                }
            }
            else
            {
                message = "로그인정보를 올바르게 입력하세요.";
            }
            ModelState.AddModelError(string.Empty, message);
            return View(login);
        }
    }
}
