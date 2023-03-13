using SeverstalTestTask.Views;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SeverstalTestTask
{
    public partial class MainWindow : Window
    {
        static int SelInd;

        public MainWindow()
        {
            InitializeComponent();
            //При загрузке приложения сразу проверяются уже существующие заметки и выносятся в список
            Commands.FillListNotes(Commands.CheckFiles(), ListNotes);
        }

        //Кнопка "Сохранить" сохраняет текст из приложения в файл в папке Notes
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Commands.SaveText(NoteText, ListNotes);
        }

        //Кнопка "Создать" открывает форму для создания новой заметки
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CreateNoteWindow();
            window.Show();
        }

        //Данная функция открывает ссылку на мой гитхаб в браузере по умолчанию :)
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(gitlink.NavigateUri.ToString());
        }

        //Событие Activated происходит или в случае создания новой заметки, или в случае переключения окна,
        //поэтому обработчик обновляет список заметок на случай создания новой
        //а так же возвращает сохраненный при деактивации окна индекс заметки в списке, чтобы сохранить прогресс работы с ней
        private void Window_Activated(object sender, EventArgs e)
        {
            Commands.FillListNotes(Commands.CheckFiles(), ListNotes);
            ListNotes.SelectedIndex = SelInd;
        }

        //Обработчик Deactivated сохраняет индекс выбранной заметки для удобной работы ListBox, а так же сохраняет
        //текст в документ для сохранения прогресса
        private void Window_Deactivated(object sender, EventArgs e)
        {
            SelInd = ListNotes.SelectedIndex;
            Commands.SaveText(NoteText, ListNotes);
        }

        //Данный обработчик выводит текст выбранной заметки в приложение
        private void ListNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Предварительно текстовое поле очищается
            NoteText.Document.Blocks.Clear();
            //Собирается индекс выбранной заметки и массив файлов заметок на диске
            var index = ListNotes.SelectedIndex;
            var files = Commands.CheckFilesFull();
            if (index != -1)
            {
                //Текстовое поле переключается в состояние "Видимое" на случай, если оно было деактивировано
                NoteText.Visibility = Visibility.Visible;
                //По ранее собранному индексу находится файл заметки, текст из него прочитывается и записывается в текстовое поле
                var content = File.ReadAllText(files[index]);
                NoteText.AppendText(content);
            } else
            {
                //если нет выбранной заметки, текстовое поле скрывается
                NoteText.Visibility = Visibility.Hidden;
            }
        }

        //Функция по индексу выбранной заметки удаляет заметку из списка и файл заметки с диска
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var index = ListNotes.SelectedIndex;
            var files = Commands.CheckFilesFull();
            if (index != -1)
            {
                ListNotes.Items.RemoveAt(index);
                File.Delete(files[index]);
            }
        }

    }
}
