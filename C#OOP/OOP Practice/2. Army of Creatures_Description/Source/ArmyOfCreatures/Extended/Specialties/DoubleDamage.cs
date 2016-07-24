namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleDamage : Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds < 0 || rounds > 10)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number or rounds should be in range 1-10!");
            }

            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
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
                return currentDamage;
            }

            this.rounds--;
            return currentDamage * 2;

        }

        public override string ToString()
        {
            return string.Format("DoubleDamage({0})", this.rounds);
        }
    }
}
