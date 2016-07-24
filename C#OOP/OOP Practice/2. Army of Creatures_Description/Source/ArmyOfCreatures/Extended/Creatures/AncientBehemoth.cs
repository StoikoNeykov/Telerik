namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        public AncientBehemoth() :
            base(GlobalConstants.AncientBehemothAttack,
                    GlobalConstants.AncientBehemothDefence,
                    GlobalConstants.AncientBehemothHealth,
                    GlobalConstants.AncientBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
