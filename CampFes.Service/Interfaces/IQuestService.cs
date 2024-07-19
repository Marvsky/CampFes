using CampFes.Models.Quest;

namespace CampFes.Service.Interfaces
{
    public interface IQuestService
    {
        /// <summary>
        /// 新增題目
        /// </summary>
        /// <param name="add_Quest"></param>
        /// <returns></returns>
        string ADD_QUEST(VM_Add_Quest add_Quest);

        /// <summary>
        /// 題目查詢
        /// </summary>
        /// <param name="MSG"></param>
        /// <returns></returns>
        List<Question> QRY_QUEST(ref string MSG);

        /// <summary>
        /// 出題
        /// </summary>
        /// <param name="ans_Quest"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        VM_Post_Quest? ASK_QUEST(VM_Ask_Quest ans_Quest, ref string MSG);

        /// <summary>
        /// 答題
        /// </summary>
        /// <param name="ans_Quest"></param>
        /// <param name="MSG"></param>
        /// <returns></returns>
        string? ANSWER(VM_Ans_Quest ans_Quest, ref string MSG);
    }
}
