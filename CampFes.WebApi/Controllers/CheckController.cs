using CampFes.Models.JWT;
using CampFes.Models;
using CampFes.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CampFes.Models.Login;
using CampFes.WebApi.Utility;
using CampFes.Models.Quest;
using CampFes.Service.DataServices;

namespace CampFes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckController : ControllerBase
    {
        private ILogger Logger { get; }
        private ICheckService CheckService { get; }

        public CheckController(ILogger<LoginController> ilogger, ICheckService iCheckService)
        {
            Logger = ilogger;
            Logger.LogInformation("Nlog injeceted into CheckController");

            CheckService = iCheckService;
        }

        /// <summary>
        /// �d�߳����T
        /// </summary>
        /// <param name="nick_name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet, Route("CheckInfo")]
        public IActionResult CheckInfo([FromQuery] string nick_name,
                                       [FromQuery] string phone)
        {
            ResultModel result;

            try
            {
                if (string.IsNullOrWhiteSpace(nick_name))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = "�п�J�ʺ�"
                    };
                    return Ok(result);
                }

                if (!string.IsNullOrWhiteSpace(phone) && phone.Length != 10)
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = "�п�J������"
                    };
                    return Ok(result);
                }

                string errMsg = "";

                var checkInfo = CheckService.CheckInfo(nick_name, phone, ref errMsg);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = errMsg,
                    };

                    return Ok(result);
                }

                if (checkInfo == null)
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = "�d�L���W��T�A�нT�{����H�O�_���T"
                    };
                    return Ok(result);
                }

                if (checkInfo.IS_RECIEVED == "Y")
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = "�w���\����L�A����H:" + checkInfo.CHECKER,
                        Data = checkInfo
                    };
                    return Ok(result);
                }

                result = new ResultModel()
                {
                    Success = true,
                    Data = checkInfo
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

                return Ok(result);
            }
        }

        /// <summary>
        /// ����@�~
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="nick_name"></param>
        /// <returns></returns>
        [HttpGet, Route("CIN")]
        public IActionResult CheckIn([FromQuery] string rid,
                                     [FromQuery] string nick_name)
        {
            ResultModel result;

            try
            {
                if (string.IsNullOrWhiteSpace(rid))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = "�d��RID�o�Ͳ��`"
                    };
                    return Ok(result);
                }

                if (string.IsNullOrWhiteSpace(nick_name))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = "�п�J�ʺ�"
                    };
                    return Ok(result);
                }

                string errMsg = CheckService.CheckIn(rid, nick_name);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = errMsg,
                    };

                    return Ok(result);
                }

                result = new ResultModel()
                {
                    Success = true,
                    Message = "���즨�\�A�ХX�ܦ��e��"
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

                return Ok(result);
            }
        }
    }
}
