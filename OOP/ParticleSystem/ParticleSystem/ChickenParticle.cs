namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChickenParticle : ChaoticParticle, IRenderable, IMovingParticle
    {
        private const int ChanceToStop = 25;

        private const int TicksToStayPut = 6;

        private int ticksCount = 0;

        private bool stopped = false;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed, randomGenerator)
        {
        }

        public override IEnumerable<Particle> Update()
        {
            if (stopped)
            {
                this.ticksCount++;

                if (this.ticksCount == TicksToStayPut + 1)
                {
                    this.stopped = false;
                    this.ticksCount = 0;

                    var objectsSoFar = base.Update();
                    var finalObjects = new List<Particle>();

                    var randomSpeed = this.GetRandomAcceleration();
                    var layedParticle = new ChickenParticle(this.Position, randomSpeed, this.RandomGenerator);

                    finalObjects.AddRange(objectsSoFar);
                    finalObjects.Add(layedParticle);

                    return finalObjects;
                }

                return new List<Particle>();
            }
            else if (this.StopNow(ChanceToStop))
            {
                this.stopped = true;
                this.ticksCount++;

                return new List<Particle>();
            }
            else
            {
                return base.Update();
            }
        }

        /// <summary>
        /// By given chance get random number and decide
        /// if the particle should stop at this position
        /// <para> chance must be between 0 and 100 </para>
        /// </summary>
        private bool StopNow(int chance)
        {
            if (chance < 0 || chance > 100)
            {
                throw new ArgumentException("Chance must be between 0 and 100.");
            }

            int upperBound = 100 / chance;

            int randomChance = this.RandomGenerator.Next(upperBound);

            return randomChance == 0;
        }
    }
}
