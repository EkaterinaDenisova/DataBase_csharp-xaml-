// author �������� ���������

using WpfAppDataBase;
namespace TestProject_DB
{
    [TestClass]
    public class UnitTest_Violators
    {
        // ������������ �������� � �������� ���� ���
        [TestMethod]
        public void TestMethodGetName()
        {
            Violator violator = new Violator();

            Assert.AreEqual("", violator.Name);

            violator.Name = "����";
            Assert.AreEqual("����", violator.Name);

            violator.Name = "�����";
            Assert.AreEqual("�����", violator.Name);

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

        // ������������ �������� � �������� ���� ����� ����������
        [TestMethod]
        public void TestMethodGetCarNumber()
        {
            Violator violator = new Violator();

            Assert.AreEqual("", violator.CarNumber);

            violator.CarNumber = "�876��";
            Assert.AreEqual("�876��", violator.CarNumber);

            violator.CarNumber = "�765��";
            Assert.AreEqual("�765��", violator.CarNumber);

            violator.CarNumber = "";
            Assert.AreEqual("", violator.CarNumber);

        }

        // ������������ �������� � �������� ���� ����� ���������
        [TestMethod]
        public void TestMethodGetReceiptNumber()
        {
            Violator violator = new Violator();

            Assert.AreEqual(0, violator.ReceiptNumber);

            violator.ReceiptNumber = 785;
            Assert.AreEqual(785, violator.ReceiptNumber);

            violator.ReceiptNumber = 6987;
            Assert.AreEqual(6987, violator.ReceiptNumber);

            // �������� �������������� ����������
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

        // ������������ �������� � �������� ���� ����� ������
        [TestMethod]
        public void TestMethodGetPayment()
        {
            Violator violator = new Violator();

            Assert.AreEqual(0, violator.Payment);

            violator.Payment = 785;
            Assert.AreEqual(785, violator.Payment);

            violator.Payment = 6987.5;
            Assert.AreEqual(6987.5, violator.Payment);

            // �������� �������������� ����������
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

        // ������������ ������������ � �����������
        [TestMethod]
        public void TestMethodConstructor()
        {
            Violator violator = new Violator("������ ϸ�� ����������", "�655��", 486, 5500.56);

            Assert.AreEqual("������ ϸ�� ����������", violator.Name);
            Assert.AreEqual("�655��", violator.CarNumber);
            Assert.AreEqual(486, violator.ReceiptNumber);
            Assert.AreEqual(5500.56, violator.Payment);

            // �������� �������������� ����������
            string s = "";
            try
            {
                Violator violator1 = new Violator("������ ϸ�� ����������", "�655��", -58, 125.5);
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }

            Assert.AreEqual(s, "ReceiptNumber can't be negative");

            // �������� �������������� ����������
            s = "";
            try
            {
                Violator violator2 = new Violator("������ ϸ�� ����������", "�655��", 58, -125.5);
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }
            Assert.AreEqual(s, "Payment can't be negative");

        }



    }
}