namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    public class CyclopsKing : Creature
    {
        public CyclopsKing() 
            : base(GlobalConstants.CyclopsKingAttack,
                        GlobalConstants.CyclopsKingDefence,
                        GlobalConstants.CyclopsKingHealth,
                        GlobalConstants.CyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(3));
            this.AddSpecialty(new DoubleAttackWhenAttacking(4));
            this.AddSpecialty(new DoubleDamage(1));
        }
    }
}
