using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mes_rest_DataAccess.DataModels
{

    /// <summary>
    /// Базовый класс сущностей
    /// </summary>    
    public class BaseEntity
    {
        /// <summary>
        /// ИД записи
        /// </summary>
        [Key]
        [Comment("ИД записи")]
        [Required(ErrorMessage = "ИД обязателен")]
        [Column("id")]
        public Int64 Id { get; set; }
    }
}
