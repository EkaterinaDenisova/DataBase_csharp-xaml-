// author Денисова Екатерина

using WpfAppDataBase;
namespace TestProject_DB
{
    [TestClass]
    public class UnitTest_Violators
    {
        // тестирование геттеров и сеттеров поля Имя
        [TestMethod]
        public void TestMethodGetName()
        {
            Violator violator = new Violator();

            Assert.AreEqual("", violator.Name);

            violator.Name = "Иван";
            Assert.AreEqual("Иван", violator.Name);

            violator.Name = "Денис";
            Assert.AreEqual("Денис", violator.Name);

            /*string s = "";
            try
            {
                violator.Name = "";
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }

            Assert.AreEqual(s, "Name can't be empty");*/

            violator.Name = "";
            Assert.AreEqual("", violator.Name);


        }

        // тестирование геттеров и сеттеров поля Номер автомобиля
        [TestMethod]
        public void TestMethodGetCarNumber()
        {
            Violator violator = new Violator();

            Assert.AreEqual("", violator.CarNumber);

            violator.CarNumber = "а876пк";
            Assert.AreEqual("а876пк", violator.CarNumber);

            violator.CarNumber = "о765ре";
            Assert.AreEqual("о765ре", violator.CarNumber);

            violator.CarNumber = "";
            Assert.AreEqual("", violator.CarNumber);

        }

        // тестирование геттеров и сеттеров поля Номер квитанции
        [TestMethod]
        public void TestMethodGetReceiptNumber()
        {
            Violator violator = new Violator();

            Assert.AreEqual(0, violator.ReceiptNumber);

            violator.ReceiptNumber = 785;
            Assert.AreEqual(785, violator.ReceiptNumber);

            violator.ReceiptNumber = 6987;
            Assert.AreEqual(6987, violator.ReceiptNumber);

            // проверка выбрасываемого исключения
            string s = "";
            try
            {
                violator.ReceiptNumber = -5;
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }
           
            Assert.AreEqual(s, "ReceiptNumber can't be negative");

        }

        // тестирование геттеров и сеттеров поля Сумма оплаты
        [TestMethod]
        public void TestMethodGetPayment()
        {
            Violator violator = new Violator();

            Assert.AreEqual(0, violator.Payment);

            violator.Payment = 785;
            Assert.AreEqual(785, violator.Payment);

            violator.Payment = 6987.5;
            Assert.AreEqual(6987.5, violator.Payment);

            // проверка выбрасываемого исключения
            string s = "";
            try
            {
                violator.Payment = -854.245;
            }
            catch(Exception ex)
            {
                s = ex.Message;
            }
            Assert.AreEqual(s, "Payment can't be negative");


        }

        // тестирование конструктора с параметрами
        [TestMethod]
        public void TestMethodConstructor()
        {
            Violator violator = new Violator("Иванов Пётр Васильевич", "а655нр", 486, 5500.56);

            Assert.AreEqual("Иванов Пётр Васильевич", violator.Name);
            Assert.AreEqual("а655нр", violator.CarNumber);
            Assert.AreEqual(486, violator.ReceiptNumber);
            Assert.AreEqual(5500.56, violator.Payment);

            // проверка выбрасываемого исключения
            string s = "";
            try
            {
                Violator violator1 = new Violator("Иванов Пётр Васильевич", "а655нр", -58, 125.5);
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }

            Assert.AreEqual(s, "ReceiptNumber can't be negative");

            // проверка выбрасываемого исключения
            s = "";
            try
            {
                Violator violator2 = new Violator("Иванов Пётр Васильевич", "а655нр", 58, -125.5);
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }
            Assert.AreEqual(s, "Payment can't be negative");

        }



    }
}