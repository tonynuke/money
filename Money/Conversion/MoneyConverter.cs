using Money.Exceptions;
using System.Collections.Immutable;

namespace Money.Conversion
{
    /// <summary>
    /// Конвертер валют.
    /// </summary>
    public static class MoneyConverter
    {
        /// <summary>
        /// Конвертирует деньги <paramref name="money"/> в валюту <paramref name="currency"/>.
        /// </summary>
        /// <param name="money">Деньги.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="exchangeRates">Ставки.</param>
        /// <returns>Деньги.</returns>
        /// <exception cref="ExchangeRateNotFoundException">Если валюты денег не найдены.</exception>
        public static Money Convert(
            Money money,
            string currency,
            IReadOnlyCollection<ExchangeRate> exchangeRates)
        {
            if (TryConvert(money, currency, exchangeRates, out var convertedMoney))
            {
                return convertedMoney!;
            }

            throw new ExchangeRateNotFoundException(money.Currency, currency);
        }

        /// <summary>
        /// Конвертирует деньги <paramref name="money"/> в валюту <paramref name="currency"/>.
        /// </summary>
        /// <param name="money">Деньги.</param>
        /// <param name="currency">Валюта.</param>
        /// <param name="exchangeRates">Ставки.</param>
        /// <param name="convertedMoney">Сконвертированные деньги.</param>
        /// <returns><see langword="true"/> если удалось сконвертировать.</returns>
        /// <exception cref="ExchangeRateNotFoundException">Если валюты денег не найдены.</exception>
        public static bool TryConvert(
            Money money,
            string currency,
            IReadOnlyCollection<ExchangeRate> exchangeRates,
            out Money? convertedMoney)
        {
            var exchangeKey = new ExchangeKey(money.Currency, currency);

            var rates = exchangeRates.ToImmutableDictionary(rate => rate.ExchangeKey);
            if (!rates.TryGetValue(exchangeKey, out var exchangeRate))
            {
                convertedMoney = null;
                return false;
            }

            var amount = money.Amount * exchangeRate.Rate;
            convertedMoney = new Money(amount, currency);

            return true;
        }
    }
}
