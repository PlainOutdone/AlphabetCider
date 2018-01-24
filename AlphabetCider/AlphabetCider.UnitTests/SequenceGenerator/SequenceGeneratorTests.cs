using AlphabetCider.SequenceGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlphabetCider.UnitTests.SequenceGenerator
{
    public class SequenceGeneratorTests
    {
        [Fact]
        public static void WhenPassingInACharacterThatDoesntExistThrowOutOfRangeException()
        {
            ISequenceGenerator generator = new EncryptingSequenceGenerator();
            Assert.Throws<ArgumentOutOfRangeException>(() => generator.GenerateSequence("@"));
        }

        [Fact]
        public static void WhenPassingInRandomLettersReturnTheCorrectSequence()
        {
            ISequenceGenerator generator = new EncryptingSequenceGenerator();
            Assert.Equal("vwxyzabcdefghijklmnopqrstu", generator.GenerateSequence("V"));
            Assert.Equal("defghijklmnopqrstuvwxyzabc", generator.GenerateSequence("d"));
            Assert.Equal("rstuvwxyzabcdefghijklmnopq", generator.GenerateSequence("R"));
        }
    }
}
