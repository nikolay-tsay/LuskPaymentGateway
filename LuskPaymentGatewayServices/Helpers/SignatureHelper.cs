using System.Security.Cryptography;
using System.Text;

namespace LuskPaymentGatewayServices.Helpers
{
    public static class SignatureHelper
    {
        public static string Password { get; set; } = null!;
        public static string GetSignature(this object target)
        {
            var signatureString = new StringBuilder(); 
            foreach (var prop in target.GetType().GetProperties())
            {
                if (prop.Name == "Signature" || prop.GetValue(target) == null)
                {
                    continue;
                }
                
                if (prop.PropertyType == typeof(bool))
                {
                    signatureString.Append($"{char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1)}={((bool)prop.GetValue(target) ? 1 : 0)}&");
                }
                else if (prop.PropertyType.IsPrimitive 
                         || prop.PropertyType == typeof(decimal)
                         || prop.PropertyType == typeof(string))
                {
                    signatureString.Append($"{char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1)}={prop.GetValue(target)}&");
                }
                else
                {
                    signatureString.Append($"{char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1)}={prop.GetValue(target).GetPartialSignature()}&");
                }
            }
            signatureString.Append($"password={Password}");
            return GetHashSha256(signatureString.ToString());
        }

        private static string GetPartialSignature(this object target)
        {
            var signatureString = new StringBuilder();
            foreach (var prop in target.GetType().GetProperties())
            {
                if (prop.Name == "Signature" || prop.GetValue(target) == null)
                {
                    continue;
                }
                
                if (prop.PropertyType == typeof(bool))
                {
                    signatureString.Append($"{char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1)}={((bool)prop.GetValue(target) ? 1 : 0)}&");
                }
                else if (prop.PropertyType.IsPrimitive 
                         || prop.PropertyType == typeof(decimal) 
                         || prop.PropertyType == typeof(string))
                {
                    signatureString.Append($"{char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1)}={prop.GetValue(target)}&");
                }
                else
                {
                    signatureString.Append($"{char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1)}={prop.GetValue(target).GetPartialSignature()}&");
                }
            }

            return Encoding.UTF8.GetString(SHA256.Create(signatureString.ToString())?.Hash);
        }

        public static string GetHashSha256(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var hashstring = new SHA256Managed();
            var hash = hashstring.ComputeHash(bytes);
            var hashString = string.Empty;
            foreach (var x in hash)
            {
                hashString += string.Format("{0:x2}", x);
            }

            return hashString;
        }
    }
}
