namespace Task2.PrintStatistics.Contracts
{
    public interface IWriter
    {
        void Write(double value);

        void WriteLine(double value);
    }
}
