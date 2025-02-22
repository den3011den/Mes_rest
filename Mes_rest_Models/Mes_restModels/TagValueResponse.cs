using System.ComponentModel;

namespace Mes_rest_Models.Mes_restModels
{
    public class TagValueResponse
    {

        /// <summary>
        /// ИД записи
        /// </summary>        
        [DisplayName("Ид записи")]
        public Int64 Id { get; set; }

        /// <summary>
        /// ИД тэга
        /// </summary>                        
        [DisplayName("ИД тэга")]
        public Int64 TagId { get; set; }

        /// <summary>
        /// Тэг
        /// </summary>
        [DisplayName("Тэг")]
        public TagResponse Tag { get; set; }

        /// <summary>
        /// Метка времени значения
        /// </summary>        
        [DisplayName("Метка времени значения")]
        public DateTime TagValueTime { get; set; }


        /// <summary>
        /// Метка времени регистрации записи о значении в БД
        /// </summary>                
        [DisplayName("Метка времени регистрации записи о значении в БД")]
        public DateTime TagValueRegTime { get; set; }


        /// <summary>
        /// Целое значение
        /// </summary>
        [DisplayName("Целое значение")]
        public Int64? IntValue { get; set; }

        /// <summary>
        /// Вещественное значение
        /// </summary>        
        [DisplayName("Вещественное значение")]
        public Double? DoubleValue { get; set; }

        /// <summary>
        /// Булево значение
        /// </summary>
        [DisplayName("Булево значение")]
        public bool? BoolValue { get; set; }


        /// <summary>
        /// Строковое значение
        /// </summary>
        [DisplayName("Строковое значение")]
        public string? StringValue { get; set; }

        /// <summary>
        /// Качество значения
        /// </summary>
        [DisplayName("Качество значения")]
        public int Quality { get; set; }

    }
}
