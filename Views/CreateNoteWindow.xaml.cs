using System.IO;
using System.Windows;

namespace SeverstalTestTask.Views
{

    public partial class CreateNoteWindow : Window
    {
        public CreateNoteWindow()
        {
            InitializeComponent();
        }
        
        //Обработчик проверяет, существует ли уже заметка с таким названием, если существует - выводит предупреждение
        //если не существует - создаёт новый файл заметки на диске
        private void CreateButtonNote(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../../Notes/" + NameText.Text + ".rtf"))
                MessageBox.Show("Такая заметка уже существует!");
            else
            {
                var myFile = File.Create("../../Notes/" + NameText.Text + ".rtf");
                myFile.Close();
            }
            this.Close();
        }
    }
}
