namespace TALTechChallenge.Core.Models.Entities
{
    public class OccupationRatings
    {
        public OccupationRatings(string occupation ,string rating)
        {
            Occupation = occupation;
            Rating = rating;

        }
        public string Occupation { get; set; }
        public string Rating { get; set; }

    }
}
