using Kitchen.Models;
using Kitchen.Workers;

namespace Task_2.RefactorStatements
{
    /// <summary>
    /// Not real class - just hold the exmples in methods
    /// </summary>
    public class Refactoring
    {
        // helper for ProcessPotato
        private Chef chef = new Chef();

        //helpers for ValidateCell
        private const int MinX = 0;
        private const int MaxX = 10;
        private const int MinY = 0;
        private const int MaxY = 10;

        private bool[,] isVIsited = new bool[MaxX, MaxY];

        public void ProcessPotato(Potato potato)
        {
            if (potato != null && potato.IsPeeled && !potato.IsRotten)
            {
                chef.Cook(potato);
            }
        }

        public void ValidateCell(int x, int y)
        {
            if ((MinX < x && x < MaxX) && 
                (MinY < y && y < MaxY) &&
                !isVIsited[x, y])
            {
                VisitCell();
            }
        }

        private void VisitCell()
        {

        }
    }
}
