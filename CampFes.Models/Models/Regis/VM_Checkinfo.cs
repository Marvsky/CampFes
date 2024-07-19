namespace CampFes.Models.Regis
{
    /// <summary>
    /// 報到表
    /// </summary>
    public class VM_Checkinfo
    {
        public int RID { get; set; }

        /// <summary>
        /// 報到人暱稱
        /// </summary>
        public string? NICK_NAMES { get; set; }

        /// <summary>
        /// 領取品
        /// </summary>
        public string? ITEMS { get; set; }

        /// <summary>
        /// 營位
        /// </summary>
        public string? AREA { get; set; }

        /// <summary>
        /// 領取紀錄
        /// </summary>
        public string? IS_RECIEVED { get; set; }

        /// <summary>
        /// 實際報到人
        /// </summary>
        public string? CHECKER { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? REMARK { get; set; }

        /// <summary>
        /// 報到時間
        /// </summary>
        public DateTime? UPDATE_TIME { get; set; }
    }
}
