namespace Money
{
    /// <summary>
    /// Цена.
    /// </summary>
    /// <param name="Value">Стоимость.</param>
    /// <param name="Vat">НДС.</param>
    public record Price(
        Money Value,
        ValueAddedTax Vat
        );
}
