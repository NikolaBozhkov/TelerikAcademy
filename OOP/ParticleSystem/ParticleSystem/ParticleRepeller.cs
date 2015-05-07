using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleRepeller : Particle, IRenderable, IMovingParticle
    {
        public int RepellForcePerCoord { get; private set; }
        public int RepellRadius { get; private set; }

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repellForcePerCoord, int repellRadius)
            : base(position, speed)
        {
            this.RepellForcePerCoord = repellForcePerCoord;
            this.RepellRadius = repellRadius;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { (char)1 } };
        }
    }
}
