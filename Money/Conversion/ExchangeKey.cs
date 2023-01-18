namespace Money.Conversion
{
    /// <summary>
    /// Валюты обмена.
    /// </summary>
    /// <param name="FromCurrency">Код валюты из которой конвертируем.</param>
    /// <param name="ToCurrency">Код валюты в которую конвертируем.</param>
    public record ExchangeKey(
        string FromCurrency, 
        string ToCurrency
        );
}
