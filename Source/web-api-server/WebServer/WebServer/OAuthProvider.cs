using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
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
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            SystemsReposistory systemsReposistory = new SystemsReposistory();

            dynamic userDto = systemsReposistory.Login(context.UserName, context.Password);
            userDto.userType = 3; //
            if (userDto != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                switch (userDto.userType)
                {
                    case 1: //Quan ly
                        break;
                    case 2: //GiaoVien
                        break;
                    case 3: //HocSinh
                        {
                            identity.AddClaim(new Claim("HocSinhId", userDto.NhanVienId.ToString(CultureInfo.InvariantCulture)));
                            identity.AddClaim(new Claim("TenDangNhap", context.UserName));
                            identity.AddClaim(new Claim("TenHocSinh", userDto.TenNhanVien.ToString(CultureInfo.InvariantCulture)));
                            identity.AddClaim(new Claim("SoDienThoai", userDto.SoDienThoai.ToString(CultureInfo.InvariantCulture)));
                            identity.AddClaim(new Claim("DiaChi", userDto.DiaChi.ToString(CultureInfo.InvariantCulture)));
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

        }
    }
}