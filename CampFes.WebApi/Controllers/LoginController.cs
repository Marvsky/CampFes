using CampFes.Models;
using CampFes.Models.JWT;
using CampFes.Models.Login;
using CampFes.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampFes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// 刷讀QRCODE後 判斷走註冊或登入
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost, Route("Login")]
        public IActionResult UserLogin(VM_Login login)
        {
            ResultModel result;

            try
            {
                string errMsg;
                string status;
                (status, errMsg) = LoginService.CheckUserStatus(login.UNI_QRCODE, login.FINGERPRINT);

                VM_UserInfo? user = null;
                //status = 1 尚未註冊
                //status = 2 正常登入中
                //status = 3 已註冊但非綁定手機
                if (status == "1")
                {
                    user = LoginService.Register(login.UID, login.FINGERPRINT, ref errMsg);
                }
                else if (status == "2")
                {
                    user = LoginService.Login(login.UID, login.FINGERPRINT, ref errMsg);
                }
                else
                {
                    errMsg = ErrorMessage.L_005;
                }


                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = Utility.Utility.GetConstantValue(typeof(ErrorMessage), errMsg),
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
                //user.Token = JwtService.GenJwtToken();
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
        /// 登出
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost, Route("Logout")]
        public IActionResult UserLogout(VM_Login login)
        {
            ResultModel result;

            try
            {
                string? errMsg = LoginService.Logout(login.UID);

                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    Logger.LogError(":{ErrMsg}", errMsg);

                    result = new ResultModel()
                    {
                        Success = false,
                        Message = Utility.Utility.GetConstantValue(typeof(ErrorMessage), errMsg),
                    };

                    return BadRequest(result);
                }

                result = new ResultModel()
                {
                    Success = true,
                    Message = "登出成功"
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
        /// 解除手機綁定
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="NICK_NAME"></param>
        /// <returns></returns>
        [HttpGet, Route("Unbind")]
        public IActionResult UserUnbind(string UID, string NICK_NAME)
        {
            ResultModel result;

            try
            {
                string? errMsg = LoginService.Unbind(UID, NICK_NAME);

                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    Logger.LogError(":{ErrMsg}", errMsg);

                    result = new ResultModel()
                    {
                        Success = false,
                        Message = Utility.Utility.GetConstantValue(typeof(ErrorMessage), errMsg),
                    };

                    return BadRequest(result);
                }

                result = new ResultModel()
                {
                    Success = true,
                    Message = "解綁成功"
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
