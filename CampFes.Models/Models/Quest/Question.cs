using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.Quest
{
    /// <summary>
    /// 問題集
    /// </summary>
    public class Question
    {
        [Key]
        public int QID { get; set; }

        /// <summary>
        /// 問題
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        [Comment("問題")]
        public string? QUESTION { get; set; }

        /// <summary>
        /// 是否為複選題
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(1)")]
        [Comment("是否為複選題")]
        public string? IS_MULTI { get; set; } = "N";

        /// <summary>
        /// 選項A
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Comment("選項A")]
        public string? OPTION_A { get; set; }

        /// <summary>
        /// 選項B
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Comment("選項B")]
        public string? OPTION_B { get; set; }

        /// <summary>
        /// 選項C
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Comment("選項C")]
        public string? OPTION_C { get; set; }

        /// <summary>
        /// 選項D
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Comment("選項D")]
        public string? OPTION_D { get; set; }

        /// <summary>
        /// 答案(複選填法ex: AB)
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(4)")]
        [Comment("答案")]
        public string? CORRECT { get; set; }

        /// <summary>
        /// 提示
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        [Comment("提示")]
        public string? HINT { get; set; }

        /// <summary>
        /// 出題者
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        [Comment("出題者")]
        public string? AUTHOR { get; set; }

        /// <summary>
        /// 是否採用
        /// </summary>
        [Column(TypeName = "varchar(1)")]
        [Comment("是否採用")]
        public string? IS_USE { get; set; }
    }
}
