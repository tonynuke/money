namespace Money.Exceptions
{
    /// <summary>
    /// Валюты не совпадают.
    /// </summary>
    public class CurrenciesDoNotMatchException : Exception
    {
        private readonly string _currency;
        private readonly string _otherCurrency;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currency">Валюта.</param>
        /// <param name="otherCurrency">Другая валюта.</param>
        public CurrenciesDoNotMatchException(string currency, string otherCurrency)
        {
            _currency = currency;
            _otherCurrency = otherCurrency;
        }

        /// <inheritdoc/>
        public override string Message => $"Валюты не совпадают: {_currency} {_otherCurrency}";
    }
}
