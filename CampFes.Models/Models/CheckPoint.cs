using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models
{
    /// <summary>
    /// QRCODE使用表
    /// </summary>
    public class CheckPoint
    {
        [Key]
        public int CID { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Comment("名稱")]
        public string? NAME { get; set; }

        /// <summary>
        /// 說明
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        [Comment("說明")]
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// QRCODE條碼
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(max)")]
        [Comment("QRCODE條碼")]
        public string? QRCODE { get; set; }

        /// <summary>
        /// 問題標記
        /// </summary>
        [Column(TypeName = "int")]
        [Comment("大地遊戲用為1 否則為0")]
        public int QFLAG { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        [Comment("建立時間")]
        public DateTime? CREATE_TIME { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        [Column(TypeName = "datetime")]
        [Comment("更新時間")]
        public DateTime? UPDATE_TIME { get; set; }
    }
}
