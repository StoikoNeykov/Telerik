namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;

    public class Goblin : Creature
    {
        public Goblin() :
            base(GlobalConstants.GoblinAttack,
                GlobalConstants.GoblinDefence,
                GlobalConstants.GoblinHealth,
                GlobalConstants.GoblinDamage)
        {
        }
    }
}
