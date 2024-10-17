using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.Login
{
    /// <summary>
    /// 允許遊玩名單
    /// </summary>
    public class AllowPlayer
    {
        /// <summary>
        /// 暱稱
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Comment("暱稱")]
        public string? NICK_NAME { get; set; }

        /// <summary>
        /// 電子身分證
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(max)")]
        [Comment("電子身分證")]
        public string? UNI_QRCODE { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Column(TypeName = "nvarchar(100)")]
        [Comment("備註")]
        public string? REMARK { get; set; }

        /// <summary>
        /// 是否是工作人員
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(1)")]
        [Comment("是否是工作人員")]
        public string? IS_STAFF { get; set; } = "N";
    }
}
