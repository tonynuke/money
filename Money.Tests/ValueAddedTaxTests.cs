namespace Money.Tests
{
    public class ValueAddedTaxTests
    {
        [Fact]
        public void Calculate_value_added_tax()
        {
            var vat = ValueAddedTax.Create(13, new Money(202, Currencies.USD));
            vat.Rate.Should().Be(13);
            vat.Value.Round(2).Amount.Should().Be(23.24m);

            var vat1 = ValueAddedTax.Create(20, new Money(200, Currencies.USD));
            vat1.Rate.Should().Be(20);
            vat1.Value.Round(2).Amount.Should().Be(33.33m);
        }
    }
}
