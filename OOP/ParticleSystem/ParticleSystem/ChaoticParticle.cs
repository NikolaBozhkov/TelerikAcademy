namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChaoticParticle : Particle, IRenderable, IMovingParticle
    {
        private const int MaxSpeedPerCoordinate = 2;

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed)
        {
            this.RandomGenerator = randomGenerator;
        }

        protected Random RandomGenerator { get; private set; }

        public override IEnumerable<Particle> Update()
        {
            var randomAcceleration = GetRandomAcceleration();

            this.Accelerate(randomAcceleration);

            return base.Update();
        }

        protected virtual MatrixCoords GetRandomAcceleration()
        {
            int randomRowAcceleration = RandomGenerator.Next(-MaxSpeedPerCoordinate, MaxSpeedPerCoordinate + 1);
            int randomColAcceleration = RandomGenerator.Next(-MaxSpeedPerCoordinate, MaxSpeedPerCoordinate + 1);

            return new MatrixCoords(randomRowAcceleration, randomColAcceleration);
        }
    }
}
