namespace CampFes.Models.Qrcode
{
    /// <summary>
    /// 名牌
    /// </summary>
    public class NamePlate
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int SNO { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string? ROLE { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        public string? NICK_NAME { get; set; }

        /// <summary>
        /// 身分證序號
        /// </summary>
        public string? UNI_QRCODE { get; set; }

        /// <summary>
        /// QRCODE base64
        /// </summary>
        public string? QRCODE { get; set; }

        /// <summary>
        /// 是否可以摸彩 Y:可 N:否
        /// </summary>
        public string? EXTRA_FLAG { get; set; }
    }
}
