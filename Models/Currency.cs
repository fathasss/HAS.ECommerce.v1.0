using System.Data;
using System.Xml;

namespace HasMicroService.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public decimal Ratio { get; set; }
    }
    public enum CurrencyItem
    {
        TR = 1,
        USD = 2,
        EUR = 3,
        GBP = 4,
        CHF = 5,
        JPY = 6,
        KWD = 7
    }
}
