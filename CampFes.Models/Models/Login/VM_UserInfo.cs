namespace CampFes.Models.Login
{
    public class VM_UserInfo
    {
        public int? UID { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        public string? NICK_NAME { get; set; }

        /// <summary>
        /// 權限等級
        /// </summary>
        public int? LEVEL { get; set; }

        /// <summary>
        /// JWT
        /// </summary>
        public string? Token { get; set; }
    }
}
