using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebServer.Repository.sp;

namespace WebServer
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                string username = context.UserName;
                string password = context.Password;
                SystemsReposistory systemsReposistory = new SystemsReposistory();
                dynamic user = systemsReposistory.Login(username, password);
                if (user != null)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    switch (user.UserType)
                    {
                        case 1: //Quan ly
                            break;
                        case 2: //GiaoVien
                            break;
                        case 3: //HocSinh
                            {
                                identity.AddClaim(new Claim("UserType", user.UserType.ToString(CultureInfo.InvariantCulture)));
                                identity.AddClaim(new Claim("HocSinhId", user.HocSinhId.ToString(CultureInfo.InvariantCulture)));
                                identity.AddClaim(new Claim("TenDangNhap", context.UserName));
                                identity.AddClaim(new Claim("TenHocSinh", user.TenHocSinh.ToString(CultureInfo.InvariantCulture)));
                                identity.AddClaim(new Claim("SoDienThoai", user.SoDienThoai.ToString(CultureInfo.InvariantCulture)));
                                identity.AddClaim(new Claim("DiaChi", user.DiaChi.ToString(CultureInfo.InvariantCulture)));
                                //identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString(CultureInfo.InvariantCulture)));
                            }
                            break;
                        case 4: //Phu huynh
                            break;
                        default:
                            break;
                    }
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}