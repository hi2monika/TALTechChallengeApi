namespace TALTechChallenge.Core.Common.Helper
{
    public static class PremiumCalculatorHelper
    {
        public static double CalcalatePremium(double deathCoverAmount, double occupationRatingFactor, int age)
        {
            //Monthly Death Premium = (Death Cover amount *Occupation Rating Factor *Age)
            double numerator = deathCoverAmount * occupationRatingFactor * age;
            double denominator = 1000 * 12;
            double premium = numerator / denominator;
            return premium;
        }

    }
}
