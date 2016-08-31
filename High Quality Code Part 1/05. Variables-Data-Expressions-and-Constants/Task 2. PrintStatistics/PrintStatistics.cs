using Task2.PrintStatistics.Contracts;
using Task2.PrintStatistics.Workers;

namespace Task2.PrintStatistics
{

    public class PrintStatistics
    {
        // bad practice - made just to cover example
        private IWriter writer = new Writer();

        public void CalculateStatistics(double[] values, int count)
        {
            double max = values[0];
            double min = values[0];
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                }

                if (values[i] < min)
                {
                    min = values[i];
                }

                sum += values[i];
            }

            double average = sum / count;

            Print(this.writer, max);
      
            Print(this.writer, min);

            Print(this.writer, average);
        }

        public void Print(IWriter writer, double result)
        {
            writer.WriteLine(result);
        }
    }
}