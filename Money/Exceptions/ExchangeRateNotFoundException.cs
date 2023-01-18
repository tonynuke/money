namespace Money.Exceptions
{
    /// <summary>
    /// Не найден курс обмена.
    /// </summary>
    public class ExchangeRateNotFoundException : Exception
    {
        private readonly string _fromCurrency;
        private readonly string _toCurrency;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromCurrency">Валюта из которой конвертируем.</param>
        /// <param name="toCurrency">Валюта в которую конвертируем.</param>
        public ExchangeRateNotFoundException(string fromCurrency, string toCurrency)
        {
            _fromCurrency = fromCurrency;
            _toCurrency = toCurrency;
        }

        /// <inheritdoc/>
        public override string Message => $"Не найден курс обмена из {_fromCurrency} в {_toCurrency}";
    }
}
