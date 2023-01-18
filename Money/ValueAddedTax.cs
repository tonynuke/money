namespace Money
{
    /// <summary>
    /// НДС
    /// </summary>
    /// <param name="Rate">Ставка.</param>
    /// <param name="Value">Значение НДС.</param>
    public record ValueAddedTax(decimal Rate, Money Value)
    {
        private const int Percents = 100;

        /// <summary>
        /// Выделяет налог из цены.
        /// </summary>
        /// <param name="rate">Ставка.</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Money CalculateVat(decimal rate, Money value)
        {
            return value * rate / (Percents + rate);
        }

        /// <summary>
        /// Выделяет налог из цены.
        /// </summary>
        /// <param name="rate">Ставка.</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal CalculateVat(decimal rate, decimal value)
        {
            return value * rate / (Percents + rate);
        }

        /// <summary>
        /// Выделяет НДС из цены.
        /// </summary>
        /// <param name="rate">Ставка.</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueAddedTax Create(decimal rate, Money value)
        {
            return new ValueAddedTax(rate, CalculateVat(rate, value));
        }
    }
}
