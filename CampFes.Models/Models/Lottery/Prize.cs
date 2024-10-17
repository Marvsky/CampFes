using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.Lottery
{
    /// <summary>
    /// 獎品表
    /// </summary>
    public class Prize
    {
        [Key]
        public int PID { get; set; }

        /// <summary>
        /// 等級
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(1)")]
        [Comment("等級")]
        public string? GRADING { get; set; }

        /// <summary>
        /// 說明
        /// </summary>
        [Column(TypeName = "nvarchar(100)")]
        [Comment("說明")]
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Required]
        [Column(TypeName = "int")]
        [Comment("數量")]
        public int? QUANTITY { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Column(TypeName = "nvarchar(200)")]
        [Comment("備註")]
        public string? REMARK { get; set; }
    }
}
