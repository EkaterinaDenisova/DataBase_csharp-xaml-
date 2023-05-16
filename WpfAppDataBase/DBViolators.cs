// author Денисова Екатерина

// класс для работы с бд с использованием ObservableCollection

// ObservableCollection -- коллекция, которую можно использовать совместно с DataGrid
// Эта коллекция можеть оповещать о своём изменении DataGrid
// DataGrid, в свою очередь, автоматически поддерживает сортировки и т.п.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;       // для ObservableCollection
using System.Windows.Markup;
using System.Xml.Linq;
using System.IO;
using System.Windows.Shapes;
using Microsoft.VisualBasic.FileIO;

namespace WpfAppDataBase
{
    // класс базы данных нарушителей
    public class DBViolators
    {
        // ObservableCollection с типом данных Violator
        public ObservableCollection<Violator> coll_violators;

        // конструктор
        public DBViolators()
        {
            coll_violators = new ObservableCollection<Violator>();
        }

        // Добавление случайной записи в таблицу
       /* public void add_random_data()
        {
            Random rnd = new Random();
            // todo: static member
            //List<String> names = new List<string> { "Гвидо ван Россум ", "Бьёрн Страуструп", "Деннис Ритчи", "Дональд Эрвин Кнут" };

            coll_violators.Add(new Violator("Петров Денис Сергеевич", "а888аа", 754, 5000));
        }*/

        // метод для добавления данных
        public void add_data(string name, string car_number, int receipt_number, double payment)
        {

            // Add добавляет объект в конец очереди
            coll_violators.Add(new Violator(name, car_number, receipt_number, payment));
        }

        // метод сохранения базы данных в файл с форматом .csv
        // CSV - текстовый формат, предназначенный для представления табличных данных.
        // Строка таблицы соответствует строке текста, которая содержит одно или
        // несколько полей, разделенных запятыми.
        // count - число обхектов в бд
        // filename - название файла
        public void SaveToCSV(int count, string filename)
        {
            /*//filename += "1.csv";

            if (!File.Exists(filename))
            {
                
            }
            if (File.Exists(filename))
            {*/
                //Stream myStream;

                //using (myStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Write))
                //{

                    // StringBuilder - изменяемая строка символов
                    StringBuilder stringBuilder = new StringBuilder();
            
                    for (int i = 0; i < count; ++i)
                    {
                        // AppendLine добавляет копию указанной в качестве аргумента строки в конец текущей stringBuilder
                        stringBuilder.AppendLine(coll_violators[i].Name + ";" + coll_violators[i].CarNumber + ";" + coll_violators[i].ReceiptNumber + ";" + coll_violators[i].Payment);

                        // ToString - преобразование stringBuilder в string
                        // WriteAllText создаёт новый файл или перезаписывает существующий
                        // с именем filename, записывает в него указанную строку,
                        // используя данную кодировку и закрывает файл
                        File.WriteAllText(filename, stringBuilder.ToString(), Encoding.GetEncoding("utf-8"));
                    }
                //}
                
            //}
                
            
        }

        // метод считывания бд из файла формата .csv
        public void LoadFromCSV(string filename)
        {
            // если текущая открытая бд не пустая
            if (coll_violators.Count != 0)
            {
                // удалить все элементы коллекции
                coll_violators.Clear();
            }

            // TextFieldParser - класс, предоставляющий методы и свойства для 
            // анализа структурированных текстовых файлов
            using (TextFieldParser tfp = new TextFieldParser(filename))
            {
                // Delimited - данные в файле отделяется разделителем
                // также существуют файлы с полями фиксированного размера
                tfp.TextFieldType = FieldType.Delimited;
                // обозначение разделителя для чтения данных
                tfp.SetDelimiters(";");

                // пока не конец файла
                while (!tfp.EndOfData)
                {
                    //ReadFields - считывание всех полей в текущей строке
                    // сохранение в массив строк и перенос курсора на следующую
                    // строку файла
                    string[] fields = tfp.ReadFields();
                    
                    // добавление данных в коллекцию из массива строк
                    coll_violators.Add(new Violator(fields[0], fields[1], int.Parse(fields[2]), double.Parse(fields[3])));
                }
            }
        }

    }
}
