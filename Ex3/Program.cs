using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    class Currency
    {
        public double Value;
        public Currency(double _value)
        {
            Value = _value;
        }
    }

    class CurrenceUSD : Currency
    {
        public double USDtoRUB;
        public double USDtoEUR;
        //public double RUBtoEUR;

        public CurrenceUSD(double _value, double _rub, double _eur) : base(_value)
        {
            USDtoRUB = _rub;
            USDtoEUR = _eur;
        }

        public static implicit operator CurrenceUSD(CurrenceRUB _rub)
        {
            return new CurrenceUSD(_rub.Value * _rub.RUBtoUSD, 1 / _rub.RUBtoUSD, _rub.RUBtoEUR / _rub.RUBtoUSD);
        }

        public static explicit operator CurrenceRUB(CurrenceUSD _usd)
        {
            return new CurrenceRUB(_usd.Value * _usd.USDtoRUB, 1 / _usd.USDtoRUB, _usd.USDtoEUR / _usd.USDtoRUB);
        }

        public static implicit operator CurrenceUSD(CurrenceEUR _eur)
        {
            return new CurrenceUSD(_eur.Value * _eur.EURtoUSD, 1 / _eur.EURtoUSD, _eur.EURtoRUB / _eur.EURtoUSD);
        }

        public static explicit operator CurrenceEUR(CurrenceUSD _usd)
        {
            return new CurrenceEUR(_usd.Value * _usd.USDtoEUR, 1 / _usd.USDtoEUR, _usd.USDtoEUR / _usd.USDtoRUB);
        }
    }

    class CurrenceEUR : Currency
    {
        public double EURtoRUB;
        public double EURtoUSD;

        public CurrenceEUR(double _value, double _rub, double _usd) : base(_value)
        {
            EURtoRUB = _rub;
            EURtoUSD = _usd;
        }

        public static implicit operator CurrenceEUR(CurrenceRUB _rub)
        {
            return new CurrenceEUR(_rub.Value * _rub.RUBtoEUR, 1 / _rub.RUBtoEUR, _rub.RUBtoUSD / _rub.RUBtoEUR);
        }


        public static explicit operator CurrenceRUB(CurrenceEUR _eur)
        {
            return new CurrenceRUB(_eur.Value * _eur.EURtoRUB, 1 / _eur.EURtoRUB, _eur.EURtoUSD / _eur.EURtoRUB);
        }

        public static implicit operator CurrenceEUR(CurrenceUSD _usd)
        {
            return new CurrenceEUR(_usd.Value * _usd.USDtoEUR, _usd.USDtoRUB / _usd.USDtoEUR, 1 / _usd.USDtoEUR);
        }
        /*
        public static explicit operator CurrenceUSD(CurrenceEUR _eur1)
        {
            return new CurrenceUSD(_eur1.Value * _eur1.EURtoUSD, _eur1.EURtoRUB / _eur1.EURtoUSD, 1 / _eur1.EURtoUSD);
        }
        */

    }

    class CurrenceRUB : Currency
    {
        public double RUBtoUSD;
        public double RUBtoEUR;

        public CurrenceRUB(double _value, double _usd, double _eur) : base(_value)
        {
            RUBtoUSD = _usd;
            RUBtoEUR = _eur;
        }

        public static implicit operator CurrenceRUB(CurrenceEUR _eur)
        {
            return new CurrenceRUB(_eur.Value * _eur.EURtoRUB, _eur.EURtoUSD / _eur.EURtoRUB, 1 / _eur.EURtoRUB);
        }

        /*
        public static explicit operator CurrenceEUR(CurrenceRUB _rub)
        {
            return new CurrenceEUR(_rub.Value * _rub.RUBtoEUR, _rub.RUBtoUSD / _rub.RUBtoEUR, 1 / _rub.RUBtoEUR);
        }
        */

        public static implicit operator CurrenceRUB(CurrenceUSD _usd)
        {
            return new CurrenceRUB(_usd.Value * _usd.USDtoRUB, 1 / _usd.USDtoRUB, _usd.USDtoEUR / _usd.USDtoRUB);
        }
        /*
        public static explicit operator CurrenceUSD(CurrenceRUB _rub)
        {
            return new CurrenceUSD(_rub.Value * _rub.RUBtoUSD, 1 / _rub.RUBtoUSD, _rub.RUBtoUSD / _rub.RUBtoEUR);
        }
        */

    }
    class Program
    {
        static void Main(string[] args)
        {
            string check = "";
            Console.WriteLine("Введите курс валют:");
            Console.WriteLine("USD->RUB");
            double USDtoRUB = Double.Parse(Console.ReadLine());
            Console.WriteLine("EUR->RUB");
            double EURtoRUB = Double.Parse(Console.ReadLine());
            Console.WriteLine("EUR->USD");
            double EURtoUSD = Double.Parse(Console.ReadLine());

            Console.WriteLine("В какой валюте вы храните деньги?");
            string currency = Console.ReadLine();
            Console.WriteLine("Сколько у вас денег?");
            double value = Double.Parse(Console.ReadLine());
            CurrenceRUB myAccountR;
            CurrenceUSD myAccountU;
            CurrenceEUR myAccountE;

            if (currency == "RUB")
            {
                myAccountR = new CurrenceRUB(value, 1 / USDtoRUB, 1 / EURtoRUB);
                Console.WriteLine("RUB");
                Console.WriteLine(myAccountR.Value);
                Console.WriteLine(myAccountR.RUBtoUSD);
                Console.WriteLine(myAccountR.RUBtoEUR);

                myAccountU = (CurrenceUSD)myAccountR;
                Console.WriteLine("RUB->USD");
                Console.WriteLine(myAccountU.Value);
                Console.WriteLine(myAccountU.USDtoRUB);
                Console.WriteLine(myAccountU.USDtoEUR);

                myAccountE = myAccountR;
                Console.WriteLine("RUB->EUR");
                Console.WriteLine(myAccountE.Value);
                Console.WriteLine(myAccountE.EURtoUSD);
                Console.WriteLine(myAccountE.EURtoRUB);
            }

            if (currency == "USD")
            {
                myAccountU = new CurrenceUSD(value, USDtoRUB, 1 / EURtoUSD);
                Console.WriteLine("USD");
                Console.WriteLine(myAccountU.Value);
                Console.WriteLine(myAccountU.USDtoRUB);
                Console.WriteLine(myAccountU.USDtoEUR);

                myAccountR = myAccountU;
                Console.WriteLine("USD->RUB");
                Console.WriteLine(myAccountR.Value);
                Console.WriteLine(myAccountR.RUBtoUSD);
                Console.WriteLine(myAccountR.RUBtoEUR);

                myAccountE = myAccountU;
                Console.WriteLine("USD->EUR");
                Console.WriteLine(myAccountE.Value);
                Console.WriteLine(myAccountE.EURtoUSD);
                Console.WriteLine(myAccountE.EURtoRUB);
            }

            if (currency == "EUR")
            {
                myAccountE = new CurrenceEUR(value, EURtoRUB, EURtoUSD);
                Console.WriteLine("EUR");
                Console.WriteLine(myAccountE.Value);
                Console.WriteLine(myAccountE.EURtoUSD);
                Console.WriteLine(myAccountE.EURtoRUB);

                myAccountR = myAccountE;
                Console.WriteLine("EUR->RUB");
                Console.WriteLine(myAccountR.Value);
                Console.WriteLine(myAccountR.RUBtoUSD);
                Console.WriteLine(myAccountR.RUBtoEUR);
                myAccountU = (CurrenceUSD)myAccountE;
                Console.WriteLine("EUR->USD");
                Console.WriteLine(myAccountU.Value);
                Console.WriteLine(myAccountU.USDtoRUB);
                Console.WriteLine(myAccountU.USDtoEUR);
            }

            /*
            double i = 1 / 60.0;
            double j = 1 / 75.0;

            CurrenceUSD usd = new CurrenceUSD(1000, 60, 0.8);
            CurrenceRUB rub = new CurrenceRUB(6000, i, j);
            CurrenceEUR eur = new CurrenceEUR(7500, 75, 1.25);
            CurrenceEUR newEur;
            CurrenceRUB newRUB;
            CurrenceUSD newUsd;
            */

            /*
            Console.WriteLine("RUB");
            Console.WriteLine(rub.Value);
            Console.WriteLine(rub.RUBtoUSD);
            Console.WriteLine(rub.RUBtoEUR);


            Console.WriteLine("EUR");
            Console.WriteLine(eur.Value);
            Console.WriteLine(eur.EURtoRUB);
            Console.WriteLine(eur.EURtoUSD);


            Console.WriteLine("USD");
            Console.WriteLine(usd.Value);
            Console.WriteLine(usd.USDtoRUB);
            Console.WriteLine(usd.USDtoEUR);

            newRUB = eur;
            Console.WriteLine("EUR->RUB");
            Console.WriteLine(newRUB.Value);
            Console.WriteLine(newRUB.RUBtoUSD);
            Console.WriteLine(newRUB.RUBtoEUR);

            newRUB = usd;
            Console.WriteLine("USD->RUB");
            Console.WriteLine(newRUB.Value);
            Console.WriteLine(newRUB.RUBtoUSD);
            Console.WriteLine(newRUB.RUBtoEUR);

            newUsd = (CurrenceUSD)rub;
            Console.WriteLine("RUB->USD");
            Console.WriteLine(newUsd.Value);
            Console.WriteLine(newUsd.USDtoRUB);
            Console.WriteLine(newUsd.USDtoEUR);

            newEur = (CurrenceEUR)rub;
            Console.WriteLine("RUB->EUR");
            Console.WriteLine(newEur.Value);
            Console.WriteLine(newEur.EURtoRUB);
            Console.WriteLine(newEur.EURtoUSD);


            
            Console.WriteLine("RUB");
            Console.WriteLine(rub.Value);
            Console.WriteLine(rub.RUBtoUSD);
            Console.WriteLine(rub.RUBtoEUR);

            newEur = rub;
            Console.WriteLine("RUB->EUR");
            Console.WriteLine(newEur.Value);
            Console.WriteLine(newEur.EURtoRUB);
            Console.WriteLine(newEur.EURtoUSD);

            Console.WriteLine("EUR");
            Console.WriteLine(eur.Value);
            Console.WriteLine(eur.EURtoRUB);
            Console.WriteLine(eur.EURtoUSD);

            newRUB = (CurrenceRUB)eur;
            Console.WriteLine("EUR->RUB");
            Console.WriteLine(newRUB.Value);
            Console.WriteLine(newRUB.RUBtoUSD);
            Console.WriteLine(newRUB.RUBtoEUR);

            Console.WriteLine("EUR");
            Console.WriteLine(eur.Value);
            Console.WriteLine(eur.EURtoUSD);
            Console.WriteLine(eur.EURtoRUB);

            Console.WriteLine("USD");
            Console.WriteLine(usd.Value);
            Console.WriteLine(usd.USDtoRUB);
            Console.WriteLine(usd.USDtoEUR);

            newEur = usd;
            Console.WriteLine("USD->EUR");
            Console.WriteLine(newEur.Value);
            Console.WriteLine(newEur.EURtoRUB);
            Console.WriteLine(newEur.EURtoUSD);

            newUsd = eur;
            Console.WriteLine("EUR->USD");
            Console.WriteLine(newUsd.Value);
            Console.WriteLine(newUsd.USDtoEUR);
            Console.WriteLine(newUsd.USDtoRUB);
            





            
            Console.WriteLine("RUB");
            Console.WriteLine(rub.Value);
            Console.WriteLine(rub.RUBtoUSD);
            Console.WriteLine(rub.RUBtoEUR);

            newUsd = rub;
            Console.WriteLine("RUB->USD");
            Console.WriteLine(newUsd.Value);
            Console.WriteLine(newUsd.USDtoRUB);
            Console.WriteLine(newUsd.USDtoEUR);

            Console.WriteLine("USD");
            Console.WriteLine(usd.Value);
            Console.WriteLine(usd.USDtoRUB);
            Console.WriteLine(usd.USDtoEUR);

            newRUB = (CurrenceRUB)usd;
            Console.WriteLine("USD->RUB");
            Console.WriteLine(newRUB.Value);
            Console.WriteLine(newRUB.RUBtoUSD);
            Console.WriteLine(newRUB.RUBtoEUR);

            Console.WriteLine("EUR");
            Console.WriteLine(eur.Value);
            Console.WriteLine(eur.EURtoUSD);
            Console.WriteLine(eur.EURtoRUB);

            newUsd = eur;
            Console.WriteLine("EUR->USD");
            Console.WriteLine(newUsd.Value);
            Console.WriteLine(newUsd.USDtoRUB);
            Console.WriteLine(newUsd.USDtoEUR);

            newEur = (CurrenceEUR)usd;
            Console.WriteLine("USD->EUR");
            Console.WriteLine(eur.Value);
            Console.WriteLine(eur.EURtoUSD);
            Console.WriteLine(eur.EURtoRUB);
            */
        }
    }
}
