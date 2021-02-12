using FluentAssertions;
using System.Collections.Generic;
using TALTechChallenge.Core.Common.Helper;
using Xunit;

namespace TALTechChallenge.Core.Helper.Test
{

    public class PremiumCalculatorHelperTest
    {
        [Theory]
        [MemberData(nameof(CalculatePremiumTestCases))]
        public void CalcalatePremium(double deathCoverAmount, double occupationRatingFactor, int age, double premium)
        {
            var result = PremiumCalculatorHelper.CalcalatePremium(deathCoverAmount, occupationRatingFactor, age);
            result.Should().Be(premium);
        }

        public static IEnumerable<object[]> CalculatePremiumTestCases
        {
            get
            {
                yield return new object[]
                {
                    22.45,1.0,25,0.046770833333333331
                };
                yield return new object[]
                {
                    22.45,1.25,25,0.058463541666666667
                };
                yield return new object[]
                {
                    22.45,1.50,25,0.070156249999999989
                };
                yield return new object[]
                {
                    22.45,1.75,25,0.081848958333333333
                };
            }
        }
    }
}
