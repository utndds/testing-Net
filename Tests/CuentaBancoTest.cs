using Microsoft.VisualStudio.TestTools.UnitTesting;
using EjemploTesting;

namespace Tests
{
    [TestClass]
    public class CuentaBancoTest
    {
        [TestMethod]
        public void Debito_ConMontoCorrecto_ActualizaBalance()
        {

            double balanceInicial = 2500.00;
            double montoADebitar = 1500.00;
            double balanceEsperado = 1000.00;

            CuentaBanco cuenta = new CuentaBanco("Pepito flores", balanceInicial);

            cuenta.debitar(montoADebitar);

            double balanceFinal = cuenta.balance;
            Assert.AreEqual(balanceEsperado, balanceFinal, 0.001, "Cuenta no debita correctamente");

        }

        [TestMethod]
        public void Debito_ConMontoNegativo_TiraError()
        {

            double balanceInicial = 2500.00;
            double montoADebitar = -1500.00;

            CuentaBanco cuenta = new CuentaBanco("Pepito flores", balanceInicial);

            Assert.ThrowsException<MontoNegativoException>(() => cuenta.debitar(montoADebitar));

        }

        [TestMethod]
        public void Debito_ConMontoMayorQueBalance_TiraError()
        {

            double balanceInicial = 2500.00;
            double montoADebitar = 3500.00;
            
            CuentaBanco cuenta = new CuentaBanco("Pepito flores", balanceInicial);

            Assert.ThrowsException<MontoADebitarMayorQueBalanceException>(() => cuenta.debitar(montoADebitar));

        }

        [TestMethod]
        public void Credito_ConMontoCorrecto_ActualizaBalance()
        {

            double balanceInicial = 2500.00;
            double montoACreditar = 1500.00;
            double balanceEsperado = 4000.00;

            CuentaBanco cuenta = new CuentaBanco("Pepito flores", balanceInicial);

            cuenta.acreditar(montoACreditar);

            double balanceFinal = cuenta.balance;
            Assert.AreEqual(balanceEsperado, balanceFinal, 0.001, "Cuenta no acredita correctamente");

        }

        [TestMethod]
        public void Credito_ConMontoNegativo_TiraError()
        {

            double balanceInicial = 2500.00;
            double montoADebitar = -1500.00;

            CuentaBanco cuenta = new CuentaBanco("Pepito flores", balanceInicial);

            Assert.ThrowsException<MontoNegativoException>(() => cuenta.acreditar(montoADebitar));

        }

    }
}
