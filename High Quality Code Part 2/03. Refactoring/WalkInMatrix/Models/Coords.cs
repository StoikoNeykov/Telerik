using GameFifteen.Contracts;

namespace GameFifteen.Models
{
    public class Coords : ICoords
    {
        public Coords(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
