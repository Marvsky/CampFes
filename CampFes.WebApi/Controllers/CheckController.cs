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
        /// 查詢報到資訊
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
                        Message = "請輸入暱稱"
                    };
                    return Ok(result);
                }

                if (!string.IsNullOrWhiteSpace(phone) && phone.Length != 10)
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = "請輸入完整手機"
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
                        Message = "查無報名資訊，請確認報到人是否正確"
                    };
                    return Ok(result);
                }

                if (checkInfo.IS_RECIEVED == "Y")
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = "已成功報到過，報到人:" + checkInfo.CHECKER,
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

                //詳細Exception不傳至前端 去Log查
                result = new ResultModel()
                {
                    Success = false,
                    Message = ErrorMessage.S_001,
                };

                return Ok(result);
            }
        }

        /// <summary>
        /// 報到作業
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
                        Message = "查詢RID發生異常"
                    };
                    return Ok(result);
                }

                if (string.IsNullOrWhiteSpace(nick_name))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = "請輸入暱稱"
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
                    Message = "報到成功，請出示此畫面"
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

                return Ok(result);
            }
        }
    }
}
