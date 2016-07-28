namespace Cars.Tests.JustMock
{
    using Cars.Models;

    public class CarChild : Car
    {
        // not big deal but have constructor
        public CarChild(int id = 0, string make = null, string model = null, int year = 0)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
    }
}
