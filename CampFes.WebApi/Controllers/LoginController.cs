using CampFes.Models.JWT;
using CampFes.Models;
using CampFes.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CampFes.Models.Login;
using CampFes.WebApi.Utility;

namespace CampFes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILogger Logger { get; }
        private IJwtService JwtService { get; }
        private ILoginService LoginService { get; }

        public LoginController(ILogger<LoginController> ilogger, IJwtService iJWTService, ILoginService iLoginService)
        {
            Logger = ilogger;
            Logger.LogInformation("Nlog injeceted into LoginController");

            JwtService = iJWTService;
            LoginService = iLoginService;
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost, Route("Regis")]
        public IActionResult UserRegis(VM_Login login)
        {
            ResultModel result;

            try
            {
                string errMsg = "";

                VM_UserInfo? user = LoginService.Register(login.NICK_NAME, login.FINGERPRINT, ref errMsg);

                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = Utility.GetConstantValue(typeof(ErrorMessage), errMsg),
                    };

                    return BadRequest(result);
                }

                if (user == null)
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = ErrorMessage.L_006,
                    };

                    return BadRequest(result);
                }

                //取得Token
                user.Token = JwtService.GenJwtToken();
                result = new ResultModel()
                {
                    Success = true,
                    Message = "註冊成功",
                    Data = user
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{ErrCode}:{ErrMsg}", ErrorMessage.S_001, ex.Message);

                //詳細Exception不傳至前端 去Log查
                result = new ResultModel()
                {
                    Success = false,
                    Message = ErrorMessage.S_001,
                };

                return BadRequest(result);
            };
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost, Route("Login")]
        public IActionResult UserLogin(VM_Login login)
        {
            ResultModel result;

            try
            {
                string errMsg = "";

                VM_UserInfo? user = LoginService.Login(login.NICK_NAME, login.FINGERPRINT, ref errMsg);

                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = Utility.GetConstantValue(typeof(ErrorMessage), errMsg),
                    };

                    return BadRequest(result);
                }

                if (user == null)
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = ErrorMessage.L_006,
                    };

                    return BadRequest(result);
                }

                //取得Token
                user.Token = JwtService.GenJwtToken();
                result = new ResultModel()
                {
                    Success = true,
                    Message = "登入成功",
                    Data = user
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{ErrCode}:{ErrMsg}", ErrorMessage.S_001, ex.Message);

                //詳細Exception不傳至前端 去Log查
                result = new ResultModel()
                {
                    Success = false,
                    Message = ErrorMessage.S_001,
                };

                return BadRequest(result);
            }
        }

        /// <summary>
        /// 產生Token、Refresh Token
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Gentoken")]
        public IActionResult GenAllToken()
        {
            ResultModel result;

            try
            {
                TokenRequest tokenRequest = new()
                {
                    Token = JwtService.GenJwtToken(),
                    Refresh_Token = JwtService.GenRefreshToken(),
                };

                result = new ResultModel()
                {
                    Success = true,
                    Message = "生成Token成功",
                    Data = tokenRequest
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{ErrCode}:{ErrMsg}", ErrorMessage.S_002, ex.Message);

                //詳細Exception不傳至前端 去Log查
                result = new ResultModel()
                {
                    Success = false,
                    Message = ErrorMessage.S_002,
                };
            }

            return Ok(result);
        }

        /// <summary>
        /// 透過Refresh Token 獲取新的Token
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("Refresh")]
        public IActionResult GenNewToken()
        {
            ResultModel result;

            try
            {
                TokenRequest tokenRequest = new()
                {
                    Token = JwtService.GenJwtToken(),
                };

                result = new ResultModel()
                {
                    Success = true,
                    Message = "生成Token成功",
                    Data = tokenRequest
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{ErrCode}:{ErrMsg}", ErrorMessage.S_002, ex.Message);

                //詳細Exception不傳至前端 去Log查
                result = new ResultModel()
                {
                    Success = false,
                    Message = ErrorMessage.S_002,
                };
            }

            return Ok(result);
        }
    }
}
