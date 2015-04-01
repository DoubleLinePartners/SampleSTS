using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.Security.Claims;

namespace SampleSTS.Web.Services
{
    public class CustomSecurityTokenService : System.IdentityModel.SecurityTokenService
    {
        public CustomSecurityTokenService(SecurityTokenServiceConfiguration securityTokenServiceConfiguration)
            : base(securityTokenServiceConfiguration)
        {
        }

        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            var scope = new Scope(request.AppliesTo.Uri.AbsoluteUri,
                SecurityTokenServiceConfiguration.SigningCredentials)
            {
                TokenEncryptionRequired = false
            };
            scope.ReplyToAddress = string.IsNullOrWhiteSpace(request.ReplyTo)
                ? scope.AppliesToAddress
                : scope.ReplyToAddress;
            return scope;
        }

        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            var outgoingIdentity = new ClaimsIdentity();

            outgoingIdentity.AddClaims(principal.Claims);

            return outgoingIdentity;
        }
    }
}