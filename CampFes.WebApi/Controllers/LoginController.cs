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
        /// ���U
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

                //���oToken
                user.Token = JwtService.GenJwtToken();
                result = new ResultModel()
                {
                    Success = true,
                    Message = "���U���\",
                    Data = user
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{ErrCode}:{ErrMsg}", ErrorMessage.S_001, ex.Message);

                //�Բ�Exception���Ǧܫe�� �hLog�d
                result = new ResultModel()
                {
                    Success = false,
                    Message = ErrorMessage.S_001,
                };

                return BadRequest(result);
            };
        }

        /// <summary>
        /// �n�J
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

                //���oToken
                user.Token = JwtService.GenJwtToken();
                result = new ResultModel()
                {
                    Success = true,
                    Message = "�n�J���\",
                    Data = user
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{ErrCode}:{ErrMsg}", ErrorMessage.S_001, ex.Message);

                //�Բ�Exception���Ǧܫe�� �hLog�d
                result = new ResultModel()
                {
                    Success = false,
                    Message = ErrorMessage.S_001,
                };

                return BadRequest(result);
            }
        }

        /// <summary>
        /// ����Token�BRefresh Token
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
                    Message = "�ͦ�Token���\",
                    Data = tokenRequest
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{ErrCode}:{ErrMsg}", ErrorMessage.S_002, ex.Message);

                //�Բ�Exception���Ǧܫe�� �hLog�d
                result = new ResultModel()
                {
                    Success = false,
                    Message = ErrorMessage.S_002,
                };
            }

            return Ok(result);
        }

        /// <summary>
        /// �z�LRefresh Token ����s��Token
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
                    Message = "�ͦ�Token���\",
                    Data = tokenRequest
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{ErrCode}:{ErrMsg}", ErrorMessage.S_002, ex.Message);

                //�Բ�Exception���Ǧܫe�� �hLog�d
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
