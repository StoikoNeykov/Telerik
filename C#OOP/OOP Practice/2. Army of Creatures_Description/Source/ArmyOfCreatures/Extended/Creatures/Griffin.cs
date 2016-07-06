namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class Griffin : Creature
    {
        public Griffin() :
            base(GlobalConstants.GriffinAttack,
                GlobalConstants.GriffinDefence,
                GlobalConstants.GriffinHealth,
                GlobalConstants.GriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
            this.AddSpecialty(new AddDefenseWhenSkip(3));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
