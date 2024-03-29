﻿
namespace WebApplication5.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinmanager;

        public AccountController(UserManager<ApplicationUser> usermanager,SignInManager<ApplicationUser> signinmanager)
        {
            this._usermanager = usermanager;
            this._signinmanager = signinmanager;
        }
        public IActionResult Index()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                { UserName=model.mail,
                    Email = model.mail,
                    isAgreed = model.isAgreed

                };
               var result=await  _usermanager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        public IActionResult Register()
        {

          
            return View();
        }


    
        public async Task<IActionResult> Login(string? ReturnUrl =null)
        {
            
            LoginVM log = new LoginVM
            {
                ReturnUrl = ReturnUrl,
                ExternalLogin = (await _signinmanager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(log);
        }




        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user =  await _usermanager.FindByEmailAsync(model.mail);
                if (user != null)
                {
                   var result=await _signinmanager.PasswordSignInAsync(user,model.password,model.IsSelected,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "username(Email) or password Incorrect");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "username(Email) or password Incorrect");
                }
            }
            LoginVM log = new LoginVM
            {mail=model.mail,
            password=model.password,
            isAgreed=model.isAgreed,
            IsSelected=model.IsSelected,
            ExternalLogin = (await _signinmanager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(log);
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
        var user = await _usermanager.FindByEmailAsync(model.mail);

            if (user != null)
            {
                var token = await _usermanager.GeneratePasswordResetTokenAsync(user);

                var passwordResetLink = Url.Action("ResetPassword", "Account", new { mail=model.mail,Token=token }, Request.Scheme);

                 MailSender.mail(new MailVM { mail = model.mail,body = passwordResetLink }); ;

                //logger.Log(LogLevel.Warning, passwordResetLink);

                return RedirectToAction("ConfirmReset");
            }
            else
            {
                ViewBag.x = "mail is Invalid";
                return View(model);
            }
        }
        public IActionResult ResetPassword(string mail,string Token)
        {
            if (mail != null && Token != null)
            {
                return View();
            }
            return RedirectToAction("Register");
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            var user = await _usermanager.FindByEmailAsync(model.mail);

            if (user != null)
            {
                var result = await _usermanager.ResetPasswordAsync(user, model.Token, model.password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
            else
            {
                ViewBag.x = "Some thing wrong";
                return View(model);
            }

           
            
        }

        [HttpPost]
        public async Task<IActionResult> signout(ResetPasswordVM model)
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult ConfirmReset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {
            var redirect = Url.Action("ExternalLoginCallback", "Account");
            var properities = _signinmanager.ConfigureExternalAuthenticationProperties(provider, redirect);
            return new ChallengeResult(provider, properities);
        }

        public async Task<IActionResult> ExternalLoginCallback(string ReturnUrl=null , string remoteError = null)
        {
            ReturnUrl = ReturnUrl ?? Url.Content("~/");
            LoginVM log = new LoginVM
            {
                ReturnUrl = ReturnUrl,
                ExternalLogin = (await _signinmanager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error from External Provider:{remoteError}");
                return View("Login", log);
            }
            var info = await _signinmanager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError("", "Error Loading Externally");
                return View("Login", log);
            }
            var signinres = await _signinmanager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signinres.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var Email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (Email != null)
                {
                    var user = await _usermanager.FindByEmailAsync(Email);
                    if (user == null)
                    {
                        user = new ApplicationUser
                        {
                            Id = info.Principal.FindFirstValue(ClaimTypes.Email),
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)


                        };
                        await _usermanager.CreateAsync(user);
                        await _usermanager.AddLoginAsync(user, info);
                    }
                    
                    await _signinmanager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
            }
            ViewBag.ErrorTitle = $"Email claim do not recieved from:{info.LoginProvider}";
            ViewBag.ErrorMessage = "please contact suuport on atiffahmykhamis@gmail.com";
            return View("Error");
        }



    }
}
