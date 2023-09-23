namespace ASP_PROJ
{
    public class CalcService
    {
        public double Division(double a, double b)
        {
            return a - b;
        }
        public double Diff(double a, double b)
        {
            return a - b;
        }
        public double Sum(double a, double b)
        {
            return a + b;
        }
        public double Mult(double a, double b)
        {
            return a * b;
        }

        public string GetTime()
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime.Hour >= 12 && currentTime.Hour < 18)
            {
                return "зараз день";
            }
            else if (currentTime.Hour >= 18 && currentTime.Hour < 24)
            {
                return "зараз вечір";
            }
            else if (currentTime.Hour >= 0 && currentTime.Hour < 6)
            {
                return "зараз ніч";
            }
            else
            {
                return "зараз ранок";
            }
        }
    }
}
