using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SampleSTS.Web.Services;

namespace SampleSTS.Web.Controllers
{
    public class SecurityController : Controller
    {
        private System.IdentityModel.SecurityTokenService _securityTokenService;
        public System.IdentityModel.SecurityTokenService SecurityTokenService
        {
            get { return _securityTokenService ?? (_securityTokenService = StsFactory.GetSecurityTokenService()); }
            set { _securityTokenService = value; }
        }

        private const string ActionParameter = "wa";
        private const string SigninAction = "wsignin1.0";
        private const string SignoutAction = "wsignout1.0";
        private const string SignoutCleanupAction = "wsignoutcleanup1.0";

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Authorize()
        {
            switch (Request.QueryString[ActionParameter])
            {
                case SigninAction:
                    ActionSignon();
                    break;
                case SignoutCleanupAction:
                case SignoutAction:
                    return ActionSignout();
            }
            return null;
        }

        private void ActionSignon()
        {
            var message = (SignInRequestMessage)WSFederationMessage.CreateFromUri(Request.Url);

            var userName = User.Identity.GetUserName();

            var claims = new List<Claim> {new Claim(ClaimTypes.Name, userName)};

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            
            var responseMessage = FederatedPassiveSecurityTokenServiceOperations.ProcessSignInRequest(
                message,
                principal,
                SecurityTokenService);
            FederatedPassiveSecurityTokenServiceOperations.ProcessSignInResponse(
                responseMessage,
                System.Web.HttpContext.Current.Response);
        }

        private ActionResult ActionSignout()
        {
            var message = WSFederationMessage.CreateFromUri(Request.Url);
            string reply = null;

            if (message.GetType() == typeof(SignOutCleanupRequestMessage))
            {
                reply = ((SignOutCleanupRequestMessage)message).Reply;
            }
            else if (message.GetType() == typeof(SignOutRequestMessage))
            {
                reply = ((SignOutRequestMessage)message).Reply;
            }
            FederatedPassiveSecurityTokenServiceOperations.ProcessSignOutRequest(
                message,
                (ClaimsPrincipal)User,
                Url.Action("LogOff", "Account", new {reply }),
                System.Web.HttpContext.Current.Response);
            return Redirect(Url.Action("LogOff", "Account"));
        }
    }
}