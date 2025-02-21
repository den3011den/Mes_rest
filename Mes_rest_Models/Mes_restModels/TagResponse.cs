using System.ComponentModel;

namespace Mes_rest_Models.Mes_restModels
{
    /// <summary>
    /// Тэг
    /// </summary>
    public class TagResponse
    {
        /// <summary>
        /// ИД записи
        /// </summary>        
        [DisplayName("Ид записи")]
        public Int64 Id { get; set; }


        /// <summary>
        /// ИД родителя
        /// </summary>        
        [DisplayName("ИД родителя")]
        public Int64 ParentId { get; set; }

        /// <summary>
        /// Наименование тэга
        /// </summary>                
        [DisplayName("Наименование тэга")]
        public string Name { get; set; } = "";

        /// <summary>
        /// Описание
        /// </summary>        
        [DisplayName("Описание")]
        public string? Description { get; set; } = "";

        /// <summary>
        /// Единицы измерения
        /// </summary>
        [DisplayName("Единицы измерения")]
        public string Engunits { get; set; } = "";

    }
}
