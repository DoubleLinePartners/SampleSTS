using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace SampleSTS.Web.Services
{
    public static class CertificateFactory
    {
        public static X509Certificate2 GetCertificate()
        {
            using (var certificateStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(@"SampleSTS.Web.DLPSTSCert.pfx"))
            using (var memoryStream = new MemoryStream())
            {

                //create an x509 cert object
                certificateStream.CopyTo(memoryStream);
                return new X509Certificate2(memoryStream.ToArray(),
                   "", X509KeyStorageFlags.Exportable);
            }
        }

        public static X509SigningCredentials GetSigningCredentials()
        {
            return new X509SigningCredentials(GetCertificate());
        }
    }
}