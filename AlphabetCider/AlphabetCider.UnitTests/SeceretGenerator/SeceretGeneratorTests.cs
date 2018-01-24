using AlphabetCider.Domain.SecretGenerator;
using System;
using Xunit;

namespace AlphabetCider.UnitTests.SeceretGenerator
{
   public class SeceretGeneratorTests
    {
        [Fact]
        public static void WhenProvidedNoSecretThrowsArgumentNullException()
        {
            ISecretGenerator generator = new DefaultSecretGenerator();
            Assert.Throws<ArgumentNullException>(() => generator.GenerateSecret("", 5));
            Assert.Throws<ArgumentNullException>(() => generator.GenerateSecret(null, 5));
        }

        [Fact]
        public static void WhenProvidedAMessageLengthOfLessThanOneThrowArgumentOutOfBoundsException()
        {
            ISecretGenerator generator = new DefaultSecretGenerator();
            Assert.Throws<ArgumentOutOfRangeException>(() => generator.GenerateSecret("mysecret",0));
            Assert.Throws<ArgumentOutOfRangeException>(() => generator.GenerateSecret("mysecret", -5));
        }

        [Fact]
        public static void WhenProvidedASecretTheSameLengthAsTheMessageLengthReturnIt()
        {
            ISecretGenerator generator = new DefaultSecretGenerator();
            var expected = "testy";
            var actual = generator.GenerateSecret("testy", 5);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void WhenProvidedASecretLongerThanTheMessageLengthReturnATruncatedSecret()
        {
            ISecretGenerator generator = new DefaultSecretGenerator();
            var input = "thisismysuperlongsecret";
            var expected = "thisismy";
            var actual = generator.GenerateSecret(input, 8);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void WhenProvidedASecretShorterThanTheMessageLengthReturnARepeatedSecret()
        {
            ISecretGenerator generator = new DefaultSecretGenerator();
            var secret = "uzis";
            var message = "meetmebythetree";
            var expected = "uzisuzisuzisuzi";
            var actual = generator.GenerateSecret(secret, message.Length);

            Assert.Equal(expected, actual);
        }
    }
}
