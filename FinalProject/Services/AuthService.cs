using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Configuration; 
using System.Threading.Tasks;
using FinalCsharpProject;
//authentication operations, including registration, login, and logout, utilizing ASP.NET Core Identity components and configuration settings.
public class AuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<IdentityResult> Register(RegisterViewModel model)
    {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);
        return result;
    }

    public async Task<SignInResult> Login(LoginViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        return result;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}
