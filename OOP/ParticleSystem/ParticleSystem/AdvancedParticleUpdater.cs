namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class AdvancedParticleUpdater : ParticleUpdater, IParticleOperator
    {
        private List<Particle> currentTickParticles = new List<Particle>();
        private List<ParticleRepeller> currentTickParticleRepellers = new List<ParticleRepeller>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var potentialRepeller = p as ParticleRepeller;

            if (potentialRepeller != null)
            {
                currentTickParticleRepellers.Add(potentialRepeller);
            }
            else
            {
                currentTickParticles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in currentTickParticleRepellers)
            {
                foreach (var particle in currentTickParticles)
                {
                    var rowVariable = Math.Pow(repeller.Position.Row - particle.Position.Row, 2);
                    var colVariable = Math.Pow(repeller.Position.Col - particle.Position.Col, 2);
                    var distance = Math.Sqrt(rowVariable + colVariable);

                    if (distance <= repeller.RepellRadius)
                    {
                        var currRepellerToParticleVector = particle.Position - repeller.Position;

                        var repToParticleRow = currRepellerToParticleVector.Row;
                        repToParticleRow = DecreaseVectorCoordToPower(repeller, repToParticleRow);

                        var repToParticleCol = currRepellerToParticleVector.Col;
                        repToParticleCol = DecreaseVectorCoordToPower(repeller, repToParticleCol);

                        var currAcceleration = new MatrixCoords(repToParticleRow, repToParticleCol);

                        particle.Accelerate(currAcceleration);
                    }
                }
            }

            this.currentTickParticleRepellers.Clear();
            this.currentTickParticles.Clear();

            base.TickEnded();
        }

        private static int DecreaseVectorCoordToPower(ParticleRepeller repeller, int repellerToPCoord)
        {
            if (Math.Abs(repellerToPCoord) > repeller.RepellForcePerCoord)
            {
                repellerToPCoord = (repellerToPCoord / Math.Abs(repellerToPCoord)) * repeller.RepellForcePerCoord;
            }
            return repellerToPCoord;
        }
    }
}
