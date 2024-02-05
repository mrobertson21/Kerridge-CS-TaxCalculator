using System;
namespace TaxCalculator
{
	public interface ITaxCalc {
		decimal RoundTaxUp(decimal taxRate, decimal step);
		public decimal GetTaxRateForProduct(string product);
    }

	public class TaxCalc : ITaxCalc
	{
		public TaxCalc()
		{
		}

		public decimal RoundTaxUp(decimal value, decimal step) {
			return Math.Ceiling(value / step) * step;
		}

		public decimal GetTaxRateForProduct(string product) {
			// Normally this data would be in a database but for this exercise we have hard-coded the values for simplicity.
			decimal taxRate = 0;

			switch (product) {
				case "Music CD":
				case "Bottle of perfume":
					// 10% tax.
					taxRate = 10;
					break;

				case "Imported box of chocolates (@11.25)":
				case "Imported box of chocolates (@10.00)":
					// 5% import duty.
					taxRate = 5;
                    break;

                case "Imported bottle of perfume (@47.50)":
				case "Imported bottle of perfume (@27.99)":
					// 10% tax + 5% import duty
					taxRate = 15;
                    break;

                default:
					// Exempt.
					break;

            }

			return taxRate;
		}
	}
}

