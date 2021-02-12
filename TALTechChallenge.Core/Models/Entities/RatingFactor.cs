namespace TALTechChallenge.Core.Models.Entities
{
    public class RatingFactor
    {
        public RatingFactor(string rating, double factor)
        {
            Rating = rating;
            Factor = factor;
        }
        public string Rating { get; set; }
        public double Factor { get; set; }
    }
}
