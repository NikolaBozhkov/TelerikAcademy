namespace CinemaSystem.Reporters
{
    using System;

    using CinemaSystem.Data;

    public interface IReporter
    {
        void Report(ICinemaSystemData data, string reportFileLocation);
    }
}
