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
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Comment("暱稱")]
        public string? NICK_NAME { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Comment("備註")]
        public string? REMARK { get; set; }

        [Required]
        [Column(TypeName = "varchar(1)")]
        [Comment("是否是工作人員")]
        public string? IS_STAFF { get; set; } = "N";
    }
}
