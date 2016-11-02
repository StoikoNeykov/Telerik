using NorthWind;

namespace NWCopy
{
    class Startup
    {
        // actually 6
        static void Main()
        {
            // Just set diferent connection string in app.config and it makes code first from 
            // allready exsisting models (made with database first before that)
            
            var dbContext = new NWEntities();
            dbContext.Database.CreateIfNotExists();
        }
    }
}
