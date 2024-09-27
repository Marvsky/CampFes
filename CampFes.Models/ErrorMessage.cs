namespace CampFes.Models
{
    /// <summary>
    /// 錯誤代碼表
    /// </summary>
    public class ErrorMessage
    {
        #region L系列 登入相關
        public const string L_000 = "L-000:兄DAY，你在玩火";

        public const string L_001 = "L-001:該QRCODE未被登錄於系統內";

        public const string L_002 = "L-002:此卡片已註冊，有問題請洽營本部";

        public const string L_003 = "L-003:用戶ID不存在，有問題請洽營本部";

        public const string L_004 = "L-004:不在登入狀態，請重新登入";

        public const string L_005 = "L-005:該帳號已綁定手機，有問題與解除綁定請洽營本部";

        public const string L_006 = "L-006:登入失敗，請重新登入";

        public const string L_007 = "L-006:其他手機登入中，有問題與解除綁定請洽營本部";
        #endregion

        #region Q系列 問題相關
        public const string Q_001 = "Q-001:該QRCODE不適用於大地遊戲";

        public const string Q_002 = "Q-002:您上一題未答題完成，作答完成後請再刷一次QRCODE";

        public const string Q_003 = "Q-003:您已回答10題";

        public const string Q_004 = "Q-004:本題已作答完成";

        public const string Q_005 = "Q_005:尚未答完10題，還不能領獎";
        #endregion

        #region S系列 系統相關
        public const string S_001 = "S-001:系統嚴重錯誤";

        public const string S_002 = "S-002:系統嚴重錯誤-2"; //生成Token異常

        public const string S_003 = "S-003:您沒有權限查看";
        #endregion
    }
}
