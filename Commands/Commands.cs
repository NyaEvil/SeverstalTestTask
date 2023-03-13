using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

// Данный класс содержит статические методы, используемые в ходе программы.

class Commands
{
    //CheckFiles смотрит, какие заметки уже существуют в приложении, и возвращает отсортированный по дате создания
    //массив notes с их названиями без расширений и пути для отображения в списке
    public static string[] CheckFiles()
    {
        DirectoryInfo dirinfo = new DirectoryInfo("../../Notes/");
        //Массив files представляет собой уже отсортированный по дате массив путей к заметкам
        FileInfo[] files = dirinfo.GetFiles().OrderBy(f => f.CreationTime).ToArray();
        string[] notes = new string[files.Length];
        //Цикл формирует новый массив notes, который содержит только названия заметок
        for(int i = 0; i < files.Length;i++)
        {
            notes[i] = System.IO.Path.GetFileNameWithoutExtension(files[i].Name);
        }
        return notes;
    }

    //FillListNotes принимает два аргумента, массив с названиями заметок и Listbox, в котором необходимо создать список заметок 
    public static void FillListNotes(string[] notes, ListBox Listnotes)
    {
        //Чтобы избежать путаницы в сортировке заметок, сначала список полностью очищается
        Listnotes.Items.Clear();
        //Цикл создает Label для каждой заметки с ее названием и отправляет его в список
        for (int i =0; i<notes.Length; i++)
        {
            Label notename = new Label();
            notename.HorizontalAlignment= HorizontalAlignment.Center;
            notename.Content= notes[i];
            Listnotes.Items.Add(notename);
        }
    }

    //Метод аналогичен CheckFiles, но вместо массива с названиями заметок возвращает массив с полными путями до них
    public static string[] CheckFilesFull()
    {
        DirectoryInfo dirinfo = new DirectoryInfo("../../Notes/");
        FileInfo[] files = dirinfo.GetFiles().OrderBy(f => f.CreationTime).ToArray();
        string[] notes = new string[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            notes[i] = System.IO.Path.GetFullPath(files[i].FullName);
        }
        return notes;
    }

    //Метод сохраняет текст из поля RichTextBox в соответствующий файл
    public static void SaveText(RichTextBox rtb, ListBox listBox)
    {
        //Так как список заметок и массив с их путями отсортированы одинаково, к файлам можно обращаться по их индексу, а не по названию
        var index = listBox.SelectedIndex;
        var files = CheckFilesFull();
        if (index != -1) //Условие проверяет, что файл действительно выбран в списке, чтобы исключить ошибку "index out of range"
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            File.WriteAllText(files[index], textRange.Text);
        }
    }
}