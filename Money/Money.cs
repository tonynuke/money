using Money.Exceptions;

namespace Money
{
    /// <summary>
    /// Деньги.
    /// </summary>
    /// <param name="Amount">Количество.</param>
    /// <param name="Currency">Код валюты.</param>
    public record Money(decimal Amount, string Currency)
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static Money Zero(string currency) => new(decimal.Zero, currency);

        /// <summary>
        /// Округляет деньги.
        /// </summary>
        /// <param name="decimals">Количество знаков после запятой.</param>
        /// <returns></returns>
        public Money Round(int decimals)
        {
            var roundedValue = decimal.Round(Amount, decimals);
            return this with { Amount = roundedValue };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="CurrenciesDoNotMatchException"></exception>
        public static Money operator +(Money a, Money b)
        {
            if (!a.HasSameCurrency(b))
            {
                throw new CurrenciesDoNotMatchException(a.Currency, b.Currency);
            }

            var value = a.Amount + b.Amount;
            return a with { Amount = value };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="CurrenciesDoNotMatchException"></exception>
        public static Money operator -(Money a, Money b)
        {
            if (!a.HasSameCurrency(b))
            {
                throw new CurrenciesDoNotMatchException(a.Currency, b.Currency);
            }

            var value = a.Amount - b.Amount;
            return a with { Amount = value };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Money operator *(Money a, int b)
        {
            var value = a.Amount * b;
            return a with { Amount = value };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Money operator *(Money a, decimal b)
        {
            var value = a.Amount * b;
            return a with { Amount = value };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Money operator /(Money a, decimal b)
        {
            var value = a.Amount / b;
            return a with { Amount = value };
        }

        /// <summary>
        /// Деньги имеют одинаковую валюту.
        /// </summary>
        /// <param name="other">Деньги.</param>
        /// <returns></returns>
        public bool HasSameCurrency(Money other)
        {
            return Currency == other.Currency;
        }
    }
}
