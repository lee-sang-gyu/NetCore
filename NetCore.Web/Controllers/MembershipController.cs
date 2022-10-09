using Microsoft.AspNetCore.Mvc;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;
using NetCore.Web.Models;
using NuGet.Protocol.Plugins;

namespace NetCore.Web.Controllers
{
    public class MembershipController : Controller
    {
        //의존성 주입 - 생성자
        private IUser _user;

        public MembershipController(IUser user)
        {
            _user = user;
        }
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
        //Data => Services => Web
        //Data => Services
        //Data => Web
        public IActionResult Login(LoginInfo login)
        {
            string message = string.Empty;
            //view모델 상태 체크
            if (ModelState.IsValid)
            {
                //뷰 모델
                //서비스 개념 - 1.서비스의 재사용성 2.모듈화를 통한 효율적 관리
                if (_user.MatchTheUserInfo(login))
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
