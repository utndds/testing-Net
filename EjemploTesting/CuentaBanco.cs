using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploTesting
{
    public class CuentaBanco
    {

        public string nombreCliente { get; set; }
        public double balance { get; set; }

        public CuentaBanco(string nombreCliente, double balance)
        {
            this.nombreCliente = nombreCliente;
            this.balance = balance;
        }

        public void debitar(double monto)
        {

            if(monto < 0)
            {
                throw new MontoNegativoException("El monto es un valor negativo");
            }

            if(balance < monto)
            {
                throw new MontoADebitarMayorQueBalanceException("El monto a debitar es mayor que el balance");
            }

            balance -= monto;

        }

        public void acreditar(double monto)
        {

            if (monto < 0)
            {
                throw new MontoNegativoException("El monto es un valor negativo");
            }

            balance += monto;

        }
    }

    public class MontoNegativoException : Exception {
    
        public MontoNegativoException(string msg) : base(msg)
        {
        }

    }

    public class MontoADebitarMayorQueBalanceException : Exception {
    
        public MontoADebitarMayorQueBalanceException(string msg) : base(msg)
        {

        }

    }

}
