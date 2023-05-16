
// author Денисова Екатерина
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfAppDataBase
{
    // класс Нарушитель
    public class Violator
    {
        private string name;         // имя нарушителя
        private string car_number;   // номер автомобиля
        private int receipt_number;  // номер квитанции
        private double payment;      // сумма оплаты

        // конструктор без параметров
        public Violator()
        {
            name = "";
            car_number = "";
            receipt_number = 0;
            payment = 0;
            //SetName("");
            //SetCarNumber("");
            //SetReceiptNumber(0);
            //SetPayment(0);
        }

        // конструктор с параметрами
        public Violator(string name1, string car_number1, int receipt_number1, double payment1)
        {
            // сеттеры
            Name = name1;
            CarNumber = car_number1;
            ReceiptNumber = receipt_number1;
            Payment = payment1;

            /*name = name1;
            car_number = car_number1;
            receipt_number = receipt_number1;
            payment = payment1;*/
            //SetName(name);
            //SetCarNumber(car_number);
            //SetReceiptNumber(receipt_number);
            //SetPayment(payment);
        }

        // геттер и сеттер имени
        public string Name {
            get { return name; }
            set 
            { 
                /*if (value == "")
                {
                    throw new Exception("Name can't be empty");
                }
                else
                {*/
                    name = value;
                //}
                 
            }
        }

        // геттер и сеттер номера автомобиля
        public string CarNumber
        {
            get { return car_number; }
            set 
            {
                /*if (value == "")
                {
                    throw new Exception("Car number can't be empty");
                }
                else
                {*/
                    car_number = value;
                //}
                     
            }
        }

        // геттер и сеттер номера квитанции
        public int ReceiptNumber
        {
            get { return receipt_number; }
            set 
            { 
                //if(!int.TryParse(value, out receipt_number))

                // значение не может быть отрицательным
                if (value < 0)
                {
                    throw new Exception("ReceiptNumber can't be negative");
                }
                else
                {
                    receipt_number = value;
                }
                 
            }
        }

        // геттер и сеттер стоимости оплаты
        public double Payment
        {
            get { return payment; }
            set 
            {
                //if(!double.TryParse(value, out payment))

                // значение не может быть отрицательным
                if (value < 0)
                {
                    throw new Exception("Payment can't be negative");
                }
                else
                {
                    payment = value;
                }
                
            }
        }

        /*public void SetName(string _name)
        {
            name = _name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetCarNumber(string _car_number)
        {
            car_number = _car_number;
        }

        public string GetCarNumber()
        {
            return car_number;
        }

        public void SetReceiptNumber(int _receipt_number)
        {
            receipt_number = _receipt_number;
        }

        public int GetReceiptNumber()
        {
            return receipt_number;
        }

        public void SetPayment(double _payment)
        {
            payment = _payment;
        }

        public double GetPayment()
        {
            return payment;
        }*/

    }
}

