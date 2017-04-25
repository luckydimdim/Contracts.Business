using System;

namespace Cmas.BusinessLayers.Contracts.Entities
{
    public class Contract
    {
        public string Id;

        public DateTime UpdatedAt;

        public DateTime CreatedAt;
        
        public string Name;

        public string Number;

        public string StartDate;

        public string FinishDate;

        public string ContractorName;

        public string Currency;

        public string Amount;

        public bool VatIncluded;

        public string ConstructionObjectName;

        public string ConstructionObjectTitleName;

        public string ConstructionObjectTitleCode;

        public string Description;

        /// <summary>
        /// Системное имя шаблона для НЗ и TS
        /// </summary>
        public string TemplateSysName;
    }
}
