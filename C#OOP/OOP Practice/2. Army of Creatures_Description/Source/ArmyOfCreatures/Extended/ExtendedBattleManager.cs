namespace ArmyOfCreatures.Extended
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Logic;
    using Logic.Battles;

    public class ExtendedBattleManager : BattleManager, IBattleManager
    {
        private readonly ICollection<ICreaturesInBattle> thirdArmyCreatures;

        private readonly ICollection<ICreaturesInBattle> fourthArmyCreatures;

        public ExtendedBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
            : base(creaturesFactory, logger)
        {
            this.thirdArmyCreatures = new List<ICreaturesInBattle>();
            this.fourthArmyCreatures = new List<ICreaturesInBattle>();
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier == null)
            {
                throw new ArgumentNullException("creatureIdentifier");
            }

            if (creaturesInBattle == null)
            {
                throw new ArgumentNullException("creaturesInBattle");
            }

            if (creatureIdentifier.ArmyNumber == 3)
            {
                this.thirdArmyCreatures.Add(creaturesInBattle);
            }
            else if (creatureIdentifier.ArmyNumber == 4)
            {
                this.fourthArmyCreatures.Add(creaturesInBattle);
            }
            else
            {
                base.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);
            }
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }

            if (identifier.ArmyNumber == 3)
            {
                return this.thirdArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }

            if (identifier.ArmyNumber == 4)
            {
                return this.fourthArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
            }

            return base.GetByIdentifier(identifier);
        }
    }
}
