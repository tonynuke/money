namespace Money.Conversion
{
    /// <summary>
    /// Ставка обмена валюты.
    /// </summary>
    /// <param name="ExchangeKey">Коды валют обмена.</param>
    /// <param name="Rate">Ставка обмена.</param>
    public record ExchangeRate(
        ExchangeKey ExchangeKey,
        decimal Rate
        );
}
