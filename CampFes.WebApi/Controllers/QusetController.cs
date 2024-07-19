using CampFes.Models;
using CampFes.Models.Quest;
using CampFes.Service.Interfaces;
using CampFes.WebApi.Utility;
using Microsoft.AspNetCore.Mvc;

namespace CampFes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QusetController : ControllerBase
    {
        private ILogger Logger { get; }
        private IQuestService QuestService { get; }

        public QusetController(ILogger<LoginController> ilogger, IQuestService iQuestService)
        {
            Logger = ilogger;
            Logger.LogInformation("Nlog injeceted into QusetController");

            QuestService = iQuestService;
        }

        /// <summary>
        /// �s�W�@�D�D��
        /// </summary>
        /// <param name="question"></param>
        /// <param name="is_multi"></param>
        /// <param name="option_a"></param>
        /// <param name="option_b"></param>
        /// <param name="option_c"></param>
        /// <param name="option_d"></param>
        /// <param name="correct"></param>
        /// <param name="hint"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost, Route("Add_Quest")]
        public IActionResult Add_Single_Question([FromQuery] string? question,
                                                 [FromQuery] string? is_multi,
                                                 [FromQuery] string? option_a,
                                                 [FromQuery] string? option_b,
                                                 [FromQuery] string? option_c,
                                                 [FromQuery] string? option_d,
                                                 [FromQuery] string? correct,
                                                 [FromQuery] string? hint,
                                                 [FromQuery] string? author)
        {
            ResultModel result;

            try
            {
                string errMsg = "";

                VM_Add_Quest add_Quest = new()
                {
                    QUESTION = question,
                    IS_MULTI = is_multi,
                    OPTION_A = option_a,
                    OPTION_B = option_b,
                    OPTION_C = option_c,
                    OPTION_D = option_d,
                    CORRECT = correct,
                    HINT = hint,
                    AUTHOR = author,
                };

                errMsg = QuestService.ADD_QUEST(add_Quest);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = errMsg,
                    };

                    return BadRequest(result);
                }

                result = new ResultModel()
                {
                    Success = true,
                    Message = "�s�W�D�ئ��\",
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
                    Message = ErrorMessage.S_001 + ":" + ex.Message,
                };

                return BadRequest(result);
            }
        }

        /// <summary>
        /// �s�W�h�D�D��
        /// </summary>
        /// <param name="add_Quests"></param>
        /// <returns></returns>
        [HttpPost, Route("Add_QuestS")]
        public IActionResult Add_MultiPle_Questions(List<VM_Add_Quest> add_Quests)
        {
            ResultModel result;

            try
            {
                string errMsg = "";

                foreach (var item in add_Quests)
                {
                    errMsg = QuestService.ADD_QUEST(item);
                    if (!string.IsNullOrWhiteSpace(errMsg))
                    {
                        result = new ResultModel()
                        {
                            Success = false,
                            Message = errMsg,
                        };

                        return BadRequest(result);
                    }
                }

                result = new ResultModel()
                {
                    Success = true,
                    Message = "�s�W�D�ئ��\",
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
                    Message = ErrorMessage.S_001 + ":" + ex.Message,
                };

                return BadRequest(result);
            }
        }

        /// <summary>
        /// �d���D�w
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Qry_Quest")]
        public IActionResult Qry_Questions()
        {
            ResultModel result;

            try
            {
                string errMsg = "";

                var questList = QuestService.QRY_QUEST(ref errMsg);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = errMsg,
                    };

                    return BadRequest(result);
                }

                result = new ResultModel()
                {
                    Success = true,
                    Message = "�d�ߦ��\",
                    Data = questList,
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
                    Message = ErrorMessage.S_001 + ":" + ex.Message,
                };

                return BadRequest(result);
            }
        }

        /// <summary>
        /// �X�D
        /// </summary>
        /// <param name="ask_Quest"></param>
        /// <returns></returns>
        [HttpPost, Route("Ask_Quest")]
        public IActionResult Ask_Question(VM_Ask_Quest ask_Quest)
        {
            ResultModel result;

            try
            {
                string errMsg = "";

                var post = QuestService.ASK_QUEST(ask_Quest, ref errMsg);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = Utility.GetConstantValue(typeof(ErrorMessage), errMsg),
                    };

                    return BadRequest(result);
                }

                result = new ResultModel()
                {
                    Success = true,
                    Message = "�o�G���\",
                    Data = post,
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
                    Message = ErrorMessage.S_001 + ":" + ex.Message,
                };

                return BadRequest(result);
            }
        }

        /// <summary>
        /// ���D
        /// </summary>
        /// <param name="ans_Quest"></param>
        /// <returns></returns>
        [HttpPost, Route("Ans_Quest")]
        public IActionResult Ans_Question(VM_Ans_Quest ans_Quest)
        {
            ResultModel result;

            try
            {
                string errMsg = "";

                //���T����
                var correct = QuestService.ANSWER(ans_Quest, ref errMsg);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    result = new ResultModel()
                    {
                        Success = false,
                        Message = Utility.GetConstantValue(typeof(ErrorMessage), errMsg),
                    };

                    return BadRequest(result);
                }

                if (correct != ans_Quest.ANSWER)
                {
                    correct = "���T���׬O:" + correct;
                }
                else
                {
                    correct = "";
                }

                result = new ResultModel()
                {
                    Success = true,
                    Message = correct,
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
                    Message = ErrorMessage.S_001 + ":" + ex.Message,
                };

                return BadRequest(result);
            }
        }
    }
}
