using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using SudokuDP1.Factory.Parser;
using System;
using System.IO;
using System.Windows.Input;

namespace SudokuDP1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Commands
        public ICommand OpenFilePicker { get; set; }

        //Variables
        private ConcreteParser parser = new ConcreteParser();


        public MainViewModel()
        {
            OpenFilePicker = new RelayCommand(FilePicker);
        }

        public void FilePicker() 
        {
            string workingDirectory = Environment.CurrentDirectory;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "\\FileReader\\Files";
            if (dialog.ShowDialog() == true)
            {
                Console.WriteLine(dialog.FileName);
                parser.Parse(dialog.FileName);
            }
        }
    }
}