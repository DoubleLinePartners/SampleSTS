using System;
using System.Configuration;
using System.IdentityModel.Configuration;

namespace SampleSTS.Web.Services
{
    public static class StsFactory
    {
        public static System.IdentityModel.SecurityTokenService GetSecurityTokenService()
        {
            var config = new SecurityTokenServiceConfiguration(
                ConfigurationManager.AppSettings["stsName"],
                CertificateFactory.GetSigningCredentials())
            {
                DefaultTokenLifetime = new TimeSpan(1, 0, 0, 0)
            };
            return new CustomSecurityTokenService(config);
        }
    }
}