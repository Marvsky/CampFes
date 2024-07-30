using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.Quest
{
    /// <summary>
    /// 答題歷程
    /// </summary>
    public class QuestHistory
    {
        /// <summary>
        /// 用戶 UID
        /// </summary>
        [Key]
        [Required]
        [Comment("用戶 UID")]
        public int UID { get; set; }

        /// <summary>
        /// 問題序號
        /// </summary>
        [Key]
        [Required]
        [Column(TypeName = "int")]
        [Comment("問題序號1~10")]
        public int QNO { get; set; }

        /// <summary>
        /// QRCODE CID
        /// </summary>
        [Required]
        [Comment("QRCODE CID")]
        public int CID { get; set; }

        /// <summary>
        /// 題目 QID
        /// </summary>
        [Required]
        [Column(TypeName = "int")]
        [Comment("題目 QID")]
        public int? QID { get; set; }

        /// <summary>
        /// 答題
        /// </summary>
        [Column(TypeName = "varchar(4)")]
        [Comment("答題")]
        public string? ANSWER { get; set; }

        /// <summary>
        /// 答題起始時間
        /// </summary>
        [Column(TypeName = "datetime")]
        [Comment("答題起始時間")]
        public DateTime? START_TIME { get; set; }

        /// <summary>
        /// 答題結束時間
        /// </summary>
        [Column(TypeName = "datetime")]
        [Comment("答題結束時間")]
        public DateTime? END_TIME { get; set; }

        /// <summary>
        /// 耗費秒數
        /// </summary>
        [Column(TypeName = "int")]
        [Comment("耗費秒數")]
        public int? SPEND_SECONDS { get; set; } 
    }
}
