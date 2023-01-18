using Money.Conversion;
using Money.Exceptions;

namespace Money.Tests
{
    public class MoneyConverterTests
    {
        [Fact]
        public void Convert_money()
        {
            var moneyUsd = new Money(10, Currencies.USD);

            var exchangeRates = new[]
            {
                new ExchangeRate(new ExchangeKey(Currencies.USD, Currencies.RUB), 61.52m)
            };
            var moneyRub = MoneyConverter.Convert(moneyUsd, Currencies.RUB, exchangeRates);
            moneyRub.Currency.Should().Be(Currencies.RUB);
            moneyRub.Amount.Should().Be(615.2m);
        }

        [Fact]
        public void Dont_convert_money_when_a_rate_was_not_found()
        {
            var moneyUsd = new Money(10, Currencies.USD);

            var action = () => MoneyConverter.Convert(moneyUsd, Currencies.RUB, Array.Empty<ExchangeRate>());
            action.Should().Throw<ExchangeRateNotFoundException>();
        }
    }
}
