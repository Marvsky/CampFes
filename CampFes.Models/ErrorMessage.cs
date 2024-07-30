namespace CampFes.Models
{
    /// <summary>
    /// 錯誤代碼表
    /// </summary>
    public class ErrorMessage
    {
        #region L系列 登入相關
        public const string L_000 = "L-000:兄DAY，你在玩火";

        public const string L_001 = "L-001:該暱稱不在報名名單內，有問題請洽營本部";

        public const string L_002 = "L-002:此暱稱已被註冊，有問題請洽營本部";

        public const string L_003 = "L-003:註冊暱稱不存在，訪客登入請用GUEST";

        public const string L_004 = "L-004:不在登入狀態，請重新登入";

        public const string L_005 = "L-005:該帳號已綁定手機，有問題與解除綁定請洽營本部";

        public const string L_006 = "L-006:登入失敗，請重新登入";
        #endregion

        #region Q系列 問題相關
        public const string Q_001 = "Q-001:該QRCODE不適用於大地遊戲";

        public const string Q_002 = "Q-002:您上一題未答題完成，不知道答案也好歹猜一下";

        public const string Q_003 = "Q-003:您已回答10題，想繼續答題請用GUEST登入";

        public const string Q_004 = "Q-004:本題已作答完成，請重新整理頁面";
        #endregion

        #region S系列 系統相關
        public const string S_001 = "S-001:系統嚴重錯誤";

        public const string S_002 = "S-002:系統嚴重錯誤-2"; //生成Token異常

        public const string S_003 = "S-003:您沒有權限查看";
        #endregion
    }
}
