namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class ParticleSystemMain
    {
        public static void Main()
        {
            Random randomGenerator = new Random();
            var renderer = new ConsoleRenderer(50, 100);
                                
            var particleUpdater = new AdvancedParticleUpdater();
                                
            var particles = new List<Particle> 
            {                   
                new Particle(new MatrixCoords(4, 20), new MatrixCoords(1, 1)),
                new ChaoticParticle(new MatrixCoords(30, 30), new MatrixCoords(0, 1), randomGenerator),
                new ChickenParticle(new MatrixCoords(25, 30), new MatrixCoords(0, 1), randomGenerator),
                new ParticleRepeller(new MatrixCoords(20, 30), new MatrixCoords(0, 0), 5, 20)
            };                  
                                
            Engine engine = new Engine(renderer, particleUpdater, particles, 150);
            engine.Run();
        }
    }
}
