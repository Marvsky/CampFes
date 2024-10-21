using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.Login
{
    public class Role
    {
        /// <summary>
        /// 角色
        /// </summary>
        [Key]
        [Column(TypeName = "varchar(20)")]
        [Comment("角色")]
        public string? ROLE { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Comment("名稱")]
        public string? NAME { get; set; }

        /// <summary>
        /// 是否有參加獎
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(1)")]
        [Comment("是否有參加獎")]
        public string? HAS_PRIZE { get; set; } = "N";

        /// <summary>
        /// 權限等級
        /// </summary>
        [Required]
        [Column(TypeName = "int")]
        [Comment("權限等級")]
        public int LEVEL { get; set; }

    }
}
