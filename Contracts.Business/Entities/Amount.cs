
namespace Cmas.BusinessLayers.Contracts.Entities
{
    /// <summary>
    /// Стоимость договора
    /// </summary>
    public class Amount
    {
        // Валюта
        public string CurrencySysName;

        // значение
        public double Value = 0;
    }
}
