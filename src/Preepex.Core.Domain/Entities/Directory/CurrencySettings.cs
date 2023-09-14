using Preepex.Core.Domain.Entities.Media;

namespace Preepex.Core.Domain.Entities.Directory
{
    public class CurrencySettings : ISettings
    {
        public bool DisplayCurrencyLabel { get; set; }

        public int PrimaryStoreCurrencyId { get; set; }

        public int PrimaryExchangeRateCurrencyId { get; set; }

        public string ActiveExchangeRateProviderSystemName { get; set; }

        public bool AutoUpdateEnabled { get; set; }
    }
}
