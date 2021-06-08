using SudokuDP1.Factory.Parser;
using System;

namespace SudokuDP1.Factory
{
    public interface IFactory<T>
    {
        void Register(string type, T obj);

        void LoadTypes();

        T Create(string type);
    }
}
