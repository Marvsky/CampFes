using CampFes.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CampFes.Service.DataServices
{
    public class JwtService : IJwtService
    {
        private IConfiguration Configuration { get; }

        public JwtService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 產生JWT Token
        /// </summary>
        /// <returns></returns>
        public string GenJwtToken()
        {
            string serializeToken;

            try
            {
                //自定義宣告物件
                ClaimsIdentity userClaimsIdentity = new(
                [
                    new Claim("Token_type", "Token")
                ]);

                //取得簽章
                SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(Configuration["JwtSettings:SignKey"]));

                //使用HmacSha256進行加密
                SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

                //建立Token內容實體
                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    Issuer = Configuration["JwtSettings:Issuer"],                                            // 設置發行者資訊
                    Audience = Configuration["JwtSettings:Audience"],                                        // 設置驗證發行者對象
                    NotBefore = DateTime.UtcNow,                                                             // 設置可用時間，預設值就是 DateTime.UtcNow
                    IssuedAt = DateTime.UtcNow,                                                              // 設置發行時間，預設值就是 DateTime.UtcNow
                    Subject = userClaimsIdentity,                                                            // Token 針對User資訊內容物件
                    SigningCredentials = signingCredentials,                                                 // Token簽章

                    //建立Token有效期限
                    Expires = DateTime.UtcNow.AddSeconds(double.Parse(Configuration["JwtSettings:TokenExpires"])),
                };

                //產生JWT Token並轉換成字串
                JwtSecurityTokenHandler tokenHandler = new(); // 建立一個JWT Token處理容器
                var securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);  // 將Token內容實體放入JWT Token處理容器

                serializeToken = tokenHandler.WriteToken(securityToken); // 最後將JWT Token處理容器序列化，這一個就是最後會需要的Token 字串

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return serializeToken;
        }

        /// <summary>
        /// 產生JWT Refresh Token
        /// </summary>
        /// <returns></returns>
        public string GenRefreshToken()
        {
            string serializeToken;

            try
            {
                //自定義宣告物件
                ClaimsIdentity userClaimsIdentity = new(
                [
                    new Claim("Token_type", "Refresh_Token")
                ]);

                //取得簽章
                SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(Configuration["JwtSettings:SignKey"]));

                //使用HmacSha256進行加密
                SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

                //建立Token內容實體
                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    Issuer = Configuration["JwtSettings:Issuer"],                // 設置發行者資訊
                    Audience = Configuration["JwtSettings:Audience"],            // 設置驗證發行者對象
                    NotBefore = DateTime.UtcNow,                                 // 設置可用時間，預設值就是 DateTime.UtcNow
                    IssuedAt = DateTime.UtcNow,                                  // 設置發行時間，預設值就是 DateTime.UtcNow
                    Subject = userClaimsIdentity,                                // Token 針對User資訊內容物件
                    SigningCredentials = signingCredentials,                     // Token簽章

                    //建立Token有效期限
                    Expires = DateTime.UtcNow.AddSeconds(double.Parse(Configuration["JwtSettings:RefreshExpires"])),
                };

                //產生JWT Token並轉換成字串
                JwtSecurityTokenHandler tokenHandler = new(); // 建立一個JWT Token處理容器
                var securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);  // 將Token內容實體放入JWT Token處理容器

                serializeToken = tokenHandler.WriteToken(securityToken); // 最後將JWT Token處理容器序列化，這一個就是最後會需要的Token 字串

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return serializeToken;
        }

        /// <summary>
        /// 產生JWT Token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="jti"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GenJwtToken(string user, string jti)
        {
            string serializeToken;

            try
            {
                //自定義宣告物件
                ClaimsIdentity userClaimsIdentity = new(
                [
                    new Claim("user", user),
                    new Claim(JwtRegisteredClaimNames.Jti, jti),

                    //自定義Claim
                    //new Claim("CustomClaim", "Anything You Like")
                ]);

                //取得簽章
                SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(Configuration["JwtSettings:SignKey"]));

                //使用HmacSha256進行加密
                SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

                //建立Token內容實體
                SecurityTokenDescriptor tokenDescriptor = new()
                {
                    Issuer = Configuration["JwtSettings:Issuer"],                // 設置發行者資訊
                    Audience = Configuration["JwtSettings:Audience"],            // 設置驗證發行者對象
                    NotBefore = DateTime.UtcNow,                                 // 設置可用時間，預設值就是 DateTime.UtcNow
                    IssuedAt = DateTime.UtcNow,                                  // 設置發行時間，預設值就是 DateTime.UtcNow
                    Subject = userClaimsIdentity,                                // Token 針對User資訊內容物件
                    SigningCredentials = signingCredentials,                     // Token簽章

                    //建立Token有效期限
                    Expires = DateTime.UtcNow.AddSeconds(double.Parse(Configuration["JwtSettings:TokenExpires"])),
                };

                //產生JWT Token並轉換成字串
                JwtSecurityTokenHandler tokenHandler = new(); // 建立一個JWT Token處理容器
                var securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);  // 將Token內容實體放入JWT Token處理容器

                serializeToken = tokenHandler.WriteToken(securityToken); // 最後將JWT Token處理容器序列化，這一個就是最後會需要的Token 字串

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return serializeToken;
        }
    }

}
