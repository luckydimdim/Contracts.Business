using System;
using System.Collections.Generic;
using System.Linq;

namespace Cmas.BusinessLayers.Contracts.Entities
{
    public class Contract
    {
        /// <summary>
        /// Внутренний идентификатор
        /// </summary>
        public string Id;

        /// <summary>
        /// Дата обновления
        /// </summary>
        public DateTime UpdatedAt;

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedAt;

        /// <summary>
        /// Название договора
        /// </summary>
        public string Name;

        /// <summary>
        /// Номер договора
        /// </summary>
        public string Number;

        /// <summary>
        /// Дата заключения
        /// </summary>
        public DateTime? StartDate;

        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime? FinishDate;

        /// <summary>
        /// Имя подрядчика
        /// </summary>
        public string ContractorName;

        /// <summary>
        /// Стоимости договора
        /// </summary>
        public IList<Amount> Amounts = new List<Amount>();

        /// <summary>
        /// НДC включен в стоимость договора
        /// </summary>
        public bool VatIncluded;

        /// <summary>
        /// Название объекта строительства
        /// </summary>
        public string ConstructionObjectName;

        /// <summary>
        /// Название объекта строительства по титульному списку
        /// </summary>
        public string ConstructionObjectTitleName;

        /// <summary>
        /// Код титульного списка объекта строительства
        /// </summary>
        public string ConstructionObjectTitleCode;

        /// <summary>
        /// Примечания к договору
        /// </summary>
        public string Description;

        /// <summary>
        /// Системное имя шаблона для НЗ и TS
        /// </summary>
        public string TemplateSysName;

        /// <summary>
        /// Валюты договора
        /// </summary>
        public IEnumerable<string> Currencies
        {
            get { return Amounts.Select(a => a.CurrencySysName).Distinct(); }
        }
    }
}