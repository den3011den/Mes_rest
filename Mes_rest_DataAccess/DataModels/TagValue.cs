using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mes_rest_DataAccess.DataModels
{
    /// <summary>
    /// Значения тэгов
    /// </summary>
    [Table("history")]
    public class TagValue : BaseEntity
    {
        /// <summary>
        /// ИД тэга
        /// </summary>        
        [Column("itemid")]
        [Required(ErrorMessage = "ИД тэга не может быть пустым")]
        public Int64 TagId { get; set; }

        /// <summary>
        /// Тэг
        /// </summary>
        [ForeignKey("TagId")]
        public virtual Tag? Tag { get; set; }

        /// <summary>
        /// Метка времени значения
        /// </summary>
        [Comment("Метка времени значения")]
        [Column("itemtimestamp")]
        [Required(ErrorMessage = "Метка времени значения не может быть пустой")]
        public DateTime TagValueTime { get; set; }


        /// <summary>
        /// Метка времени значения
        /// </summary>
        [Comment("Метка времени регистрации записи о значении в БД")]
        [Column("regtimestamp")]
        [Required(ErrorMessage = "Метка времени регистрации записи о значении в БД не может быть пустой")]
        public DateTime TagValueRegTime { get; set; }


        /// <summary>
        /// Целое значение
        /// </summary>
        [Comment("Целое значение")]
        [Column("valint")]
        public Int64? IntValue { get; set; }

        /// <summary>
        /// Вещественное значение
        /// </summary>
        [Comment("Вещественное значение")]
        [Column("valdouble")]
        public Double? DoubleValue { get; set; }

        /// <summary>
        /// Булево значение
        /// </summary>
        [Comment("Булево значение")]
        [Column("valbool")]
        public bool? BoolValue { get; set; }


        /// <summary>
        /// Строковое значение
        /// </summary>
        [Comment("Строковое значение")]
        [Column("valstring")]
        public string? StringValue { get; set; }

        /// <summary>
        /// Строковое значение
        /// </summary>
        [Comment("Строковое значение")]
        [Column("quality")]
        public int Quality { get; set; }
    }
}
