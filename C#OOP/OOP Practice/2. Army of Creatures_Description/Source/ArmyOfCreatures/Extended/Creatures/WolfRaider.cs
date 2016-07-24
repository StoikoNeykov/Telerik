namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    public class WolfRaider : Creature
    {
        public WolfRaider()
             : base(GlobalConstants.WolfRaiderAttack,
                   GlobalConstants.WolfRaiderDefence,
                   GlobalConstants.WolfRaiderHealth,
                   GlobalConstants.WolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(7));
        }
    }
}
