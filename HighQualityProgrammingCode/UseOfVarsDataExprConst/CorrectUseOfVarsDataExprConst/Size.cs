namespace CorrectUseOfVarsDataExprConst
{
    using System;

    public class Size
    {
        private readonly double width;
        private readonly double height;

        public Size(double w, double h)
        {
            this.width = w;
            this.height = h;
        }

        public static Size GetRotatedSize(Size size, double angleOfTheFigureThatWillBeRotated)
        {
            double rotatedWidth = (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotated)) * size.width) + 
                (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotated)) * size.height);

            double rotatedHeight = (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotated)) * size.width) +
                (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotated)) * size.height);

            return new Size(rotatedWidth, rotatedHeight);
        }
    }
}