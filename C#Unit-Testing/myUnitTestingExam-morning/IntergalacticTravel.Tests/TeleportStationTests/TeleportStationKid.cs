namespace IntergalacticTravel.Tests.TeleportStationTests
{

    using System.Collections.Generic;
    using IntergalacticTravel.Contracts;

    public class TeleportStationKid : TeleportStation
    {
        public TeleportStationKid(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) 
            : base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner Owner
        {
            get
            {
                return base.owner;
            }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get
            {
                return base.galacticMap;
            }
        }

        public ILocation Location
        {
            get
            {
                return base.location;
            }
        }
    }
}
