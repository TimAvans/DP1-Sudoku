using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using SudokuDP1.Controller;
using SudokuDP1.Factory.Parser;
using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace SudokuDP1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //Commands
        public ICommand OpenFilePicker { get; set; }

        public ICommand ShowCellsCommand { get; set; }

        //Properties
        public Game Game { get; set; }

        public MainViewModel()
        {
            OpenFilePicker = new RelayCommand(FilePicker);
            Game = new Game();

            ShowCellsCommand = new RelayCommand(ShowCells);
        }

        private void ShowCells()
        {
            if (Game.Sudoku != null)
            {
                foreach (Cell c in Game.Sudoku.Cells)
                {
                    Console.WriteLine(c.Value);
                }
                Console.WriteLine("--------");
            }
        }

        private void FilePicker() 
        {
            string workingDirectory = Environment.CurrentDirectory;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Directory.GetParent(workingDirectory).Parent.FullName + "\\FileReader\\Files";
            if (dialog.ShowDialog() == true)
            {
                Console.WriteLine(dialog.FileName);

                Game.MakeSudoku(dialog.FileName);
                RaisePropertyChanged("Game");
            }
        }
    }
}