using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using yummysayt.Models.Auth;
using yummysayt.ViewModels;

namespace yummysayt.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<MyAppUser> _userManager;
        private readonly SignInManager<MyAppUser> _signInManager;

        public AuthController(SignInManager<MyAppUser> signInManager, UserManager<MyAppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            MyAppUser myAppUser = new MyAppUser()
            {
                Name = registerVM.Name,
                Email = registerVM.Email,

            };
           IdentityResult registerResult = await _userManager.CreateAsync(myAppUser,registerVM.Password);
            if (!registerResult.Succeeded)
            {
                foreach (var error in registerResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
                return View(registerVM);

            }
            return RedirectToAction(nameof(login));
        }
        


    }
}
