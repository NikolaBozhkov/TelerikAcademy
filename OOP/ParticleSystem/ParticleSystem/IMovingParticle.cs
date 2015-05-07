using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public interface IMovingParticle
    {
        MatrixCoords Speed
        {
            get;
        }

        void Accelerate(MatrixCoords acceleration);
    }
}
