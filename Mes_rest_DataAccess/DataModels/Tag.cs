using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mes_rest_DataAccess.DataModels
{
    /// <summary>
    /// Справочник тэгов
    /// </summary>
    [Table("items")]
    public class Tag : BaseEntity
    {
        /// <summary>
        /// ИД родителя
        /// </summary>
        [Comment("ИД родителя")]
        [Column("parent")]
        public Int64 ParentId { get; set; }

        /// <summary>
        /// Наименование тэга
        /// </summary>
        [Comment("Наименование тэга")]
        [Column("name")]
        [Required(ErrorMessage = "Наименование не может быть пустым")]
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Comment("Описание")]
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// Единицы измерения
        /// </summary>
        [Comment("Ед. измерения")]
        [Column("engunits")]
        public string Engunits { get; set; }

    }
}
