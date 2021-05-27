using SudokuDP1.Factory.Parser;

namespace SudokuDP1.Factory
{
    public interface IFactory
    {
        void Register(string type, IParser parser);

        void LoadTypes();

        IParser Create(string type);
    }
}
