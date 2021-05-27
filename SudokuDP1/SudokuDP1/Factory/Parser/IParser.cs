namespace SudokuDP1.Factory.Parser
{
    public interface IParser
    {
        void Parse();
        IParser Clone();
        string Type();
    }
}
