namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            if (rounds < 1)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number or rounds should be in greater then 0!");
            }

            this.rounds = rounds;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            rounds--;
        }

        public override string ToString()
        {
            return string.Format("DoubleAttackWhenAttacking({0})", this.rounds);
        }
    }
}
