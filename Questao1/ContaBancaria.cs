using System.Globalization;

namespace Questao1
{
    internal class ContaBancaria
    {
        private const double Taxa = 3.50D;
        private readonly CultureInfo _outputCulture;

        internal ContaBancaria(int numero, string titular, double depositoInicial = 0.00D)
        {
            Numero = numero;
            Titular = titular;
            Saldo = depositoInicial;

            _outputCulture = new("en-US");
            _outputCulture.NumberFormat.CurrencyNegativePattern = 1;
        }

        protected int Numero { get; init; }
        protected string Titular { get; set; }
        private double Saldo { get; set; }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular: {Titular}, Saldo {Saldo.ToString("C", _outputCulture)}";
        }

        public void Deposito(double quantia)
        {
            Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            Saldo -= Taxa + quantia;
        }
    }
}