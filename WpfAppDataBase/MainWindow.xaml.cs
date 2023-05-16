// author Денисова Екатерина
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // объект класса для работы с бд
        DBViolators db_violators;

        // название файла, с которым работает пользователь в данный момент
        string filename = "";

        // конструктор
        public MainWindow()
        {
            InitializeComponent();
             
            db_violators = new DBViolators();

            // ItemsSource - задание коллекции, используемой для создания
            // содержимого DataGrid
            datagrid.ItemsSource = db_violators.coll_violators;
        }

        // проверка данных при добавлении новой строки в бд
        // с изменением цвета полей ввода с ошибочными данными
        private bool AddingCheck()
        {
            // указывает на наличие ошибки в вводимых данных
            bool thereIsError = false;

            // SolidColorBrush закрашивает область сплошным цветом
            SolidColorBrush errorColor = new SolidColorBrush();
            SolidColorBrush normalColor = new SolidColorBrush();

            // цвет при неверных данных
            errorColor.Color = Color.FromRgb(255, 187, 188);
            // цвет при допустимых данных
            normalColor.Color = Colors.White;

            if (TextBox_name.Text == "")
            {
                // Content - текст в Label
                Label_name_error.Content = "Поле не может быть пустым";
                // Background - задание кисти, описывающей фон элемента управления
                TextBox_name.Background = errorColor;
                thereIsError = true;
            }
            else
            {
                Label_name_error.Content = "";
                TextBox_name.Background = normalColor;
            }


            if (TextBox_car_number.Text == "")
            {
                Label_car_number_error.Content = "Поле не может быть пустым";
                TextBox_car_number.Background = errorColor;
                thereIsError = true;
            }
            else
            {
                Label_car_number_error.Content = "";
                TextBox_car_number.Background = normalColor;
            }


            if (TextBox_receipt_number.Text == "")
            {
                Label_receipt_number_error.Content = "Поле не может быть пустым";
                TextBox_receipt_number.Background = errorColor;
                thereIsError = true;
            }
            // если нельзя преобразовать в int
            else if (!int.TryParse(TextBox_receipt_number.Text, out int receipt)) {
                Label_receipt_number_error.Content = "Недопустимое значение";
                TextBox_receipt_number.Background = errorColor;
                thereIsError = true;
            }
            // если значение меньше нуля 
            else if (int.Parse(TextBox_receipt_number.Text) < 0)
            {
                Label_receipt_number_error.Content = "Недопустимое значение";
                TextBox_receipt_number.Background = errorColor;
                thereIsError = true;
            }
            else
            {
                Label_receipt_number_error.Content = "";
                TextBox_receipt_number.Background = normalColor;
            }


            if (TextBox_payment.Text == "")
            {
                Label_payment_error.Content = "Поле не может быть пустым";
                TextBox_payment.Background = errorColor;
                thereIsError = true;
            }
            // если нельзя преобразовать в double 
            else if (!double.TryParse(TextBox_payment.Text, out double payment))
            {
                Label_payment_error.Content = "Недопустимое значение";
                TextBox_payment.Background = errorColor;
                thereIsError = true;
            }
            // если значение меньше нуля 
            else if (double.Parse(TextBox_payment.Text) <0)
            {
                Label_payment_error.Content = "Недопустимое значение";
                TextBox_payment.Background = errorColor;
                thereIsError = true;
            }
            else
            {
                Label_payment_error.Content = "";
                TextBox_payment.Background = normalColor;
            }


            // true, если есть ошибка, иначе false
            return thereIsError;
        }

        // обработчик события нажатия кнопки "Добавить строку" 
        private void button_add_row_Click(object sender, RoutedEventArgs e)
        {
            // Label для вывода сообщения об ошибке при удалении
            Label_state_error.Content = "";

            //db_violators.add_random_data();

            // если при проверка данных в полях ввода не было обнаружено ошибок
            if (AddingCheck() == false)
            {
                string name1 = TextBox_name.Text;
                string car_number1 = TextBox_car_number.Text;
                // Convert преобразует строковые данные
                // ToInt32 - к типу int
                int receipt_number1 = Convert.ToInt32(TextBox_receipt_number.Text);
                // ToDouble - к типу double
                double payment1 = Convert.ToDouble(TextBox_payment.Text);

                // добавление данных в бд
                db_violators.add_data(name1, car_number1, receipt_number1, payment1);
            }
            



        }

        // обработчик события нажатия кнопки "Удалить строку"
        private void button_delete_row_Click(object sender, RoutedEventArgs e)
        {

            // если пользователь не выбрал строку
            // SelectedIndex - индекс строки первого выделенного элемента
            // по умолчанию -1
            if (datagrid.SelectedIndex == -1)
            {
                // сообщение о том, что нужно выделить строку
                Label_state_error.Content = "Выделите удаляемую строку";
            }
            else
            {
                Label_state_error.Content = "";
                // запоминаем индекс выделенной строки
                int row = datagrid.SelectedIndex;
                // удаляем элемент из коллекции под данным индексом
                db_violators.coll_violators.RemoveAt(row);
            }
            
        }

        // обработчик события нажатия элемента меню "Сохранить"
        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            // если до этого пользователь не открывал и не сохранял файл
            if (filename == "")
            {
                // "Сохранить" работает как "Сохранить как"
                MenuItemSaveAs_Click(sender, e);

            }
            // если пользователь уже работает с каким-то файлом
            else
            {
                // сохранить данный файл
                db_violators.SaveToCSV(datagrid.Items.Count, filename);
            }
            
            

        }

        // обработчик события нажатия элемента меню "Открыть"
        private void MenuItemLoad_Click(object sender, RoutedEventArgs e)
        {
            // OpenFileDialog - диалоговое окно для выбора файла на открытие
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // ShowDialog = true, если пользователь выбрал файл и нажал Открыть
            if (openFileDialog.ShowDialog() == true)
            {
                // сохраняется текущее название файла, с которым будет работать пользователь
                filename = openFileDialog.FileName;

               
                // считывание данных из файла в бд
                db_violators.LoadFromCSV(filename);

            }
        }

        // обработчик события нажатия элемента меню "Сохранить как"
        private void MenuItemSaveAs_Click(object sender, RoutedEventArgs e)
        {
            // SaveFileDialog - диалоговое окно для выбора файла сохранения
            SaveFileDialog saveDialog = new SaveFileDialog();
            // Filter задаёт строку филльтра, определяющую, какие типы файлов
            // отоюражаются в диалоговом окне
            saveDialog.Filter = "Comma-separated values file|*.csv*";

            // ShowDialog = true, если пользователь выбрал файл и нажал Сохранить
            if (saveDialog.ShowDialog() == true)
            {
                // сохраняется текущее название файла, с которым будет работать пользователь
                filename = saveDialog.FileName;

                //int count = datagrid.Items.Count;

                /*Stream myStream;

                using (myStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Write))
                {*/
                /*StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < count; ++i)
                {
                    stringBuilder.AppendLine(db_violators.coll_violators[i].Name + ";" + db_violators.coll_violators[i].CarNumber + ";" + db_violators.coll_violators[i].ReceiptNumber + ";" + db_violators.coll_violators[i].Payment);
                    File.WriteAllText(filename, stringBuilder.ToString(), Encoding.GetEncoding("utf-8"));
                }*/
                //}

                // сохранение бд из коллекции в файл
                db_violators.SaveToCSV(datagrid.Items.Count, filename);
                //File.WriteAllText(dialog.FileName, fileText);
            }
        }

        // обработчик события нажатия элемента меню "Выход"
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            // закрытие окна
            this.Close();
        }

        // обработчик события нажатия элемента меню "Справка"
        private void MenuItemHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Инструкция по работе с базой данных для \r\nрегистрации нарушителей " +
                "правил дорожного движения\r\n1) Чтобы добавить новую строку с данными, введите данные в \r\n" +
                "поля ввода и нажмите \"Добавить строку\" \r\n2) Чтобы удалить строку, выделите её и " +
                "нажмите \"Удалить\" \r\n" +
                "3) Чтобы изменить данные в существующей строке, введите новые значения и нажмите \"Enter\"\r\n"+
                "4) Для сортировки по столбцу, нажмите на заголовок нужного столбца\r\n",
                "Справка");
        }

        // обработчик события нажатия горячих клавиш Ctrl+S
        private void CommandBindingSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // вызов обработчика события нажатия элемента меню "Сохранить"
            MenuItemSave_Click(sender,e);
        }

        // обработчик события нажатия горячих клавиш Ctrl+O
        private void CommandBindingOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // вызов обработчика события нажатия элемента меню "Открыть"
            MenuItemLoad_Click(sender,e);
        }

        // обработчик события нажатия горячих клавиш Ctrl+Shift+S
        private void CommandBindingSaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // вызов обработчика события нажатия элемента меню "Сохранить как"
            MenuItemSaveAs_Click(sender, e);
        }

        // обработчик события нажатия горячих клавиш Alt+F4
        private void CommandBindingExit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // вызов обработчика события нажатия элемента меню "Выход"
            MenuItemExit_Click(sender, e);
        }

        // обработчик события нажатия горячих клавиш Ctrl+F1
        private void CommandBindingHelp_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // вызов обработчика события нажатия элемента меню "Справка"
            MenuItemHelp_Click(sender, e);
        }

        // обработчик события нажатия горячей клавиши Enter
        private void CommandBindingAdd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // вызов обработчика события нажатия кнопки "Добавить"
            button_add_row_Click(sender, e);
        }
    }
}
