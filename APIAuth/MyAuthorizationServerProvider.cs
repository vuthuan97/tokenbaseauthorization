using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace APIAuth
{
    public class MyAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        public override async  Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async  Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //using (UserRepository _repo = new UserRepository())
            //{
            //    var user = _repo.ValidateUser(context.UserName, context.Password);
            //    if (user == null)
            //    {
            //        context.SetError("invalid_grant", "Tài khoản hoặc mật khẩu của bạn không đúng");
            //        return;
            //    }
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            //    identity.AddClaim(new Claim(ClaimTypes.Role,user.ThanhVien.loaiThanhVien));         
            //    identity.AddClaim(new Claim(ClaimTypes.Name, user.nickName));
            //    identity.AddClaim(new Claim("Email", user.userName));
            //    context.Validated(identity);
            //}
            using (apiEntities db = new apiEntities())
            {
                var user = db.UserWeb.FirstOrDefault(c => c.userName == context.UserName && c.password == context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Tài khoản không đúng, vui lòng kiểm tra lại");
                    return;
                }
                else
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.ThanhVien.loaiThanhVien));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.nickName));
                    context.Validated(identity);
                }

            }
        }
    }
}