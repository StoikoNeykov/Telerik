namespace Cars.Tests.JustMock
{
    using Cars.Contracts;
    using Cars.Data;

    public class CarsRepoChild : CarsRepository, ICarsRepository
    {
        public CarsRepoChild(IDatabase database)
            :base(database)
        {
        }

        public IDatabase GetData()
        {
            return base.Data;
        }
    }
}
