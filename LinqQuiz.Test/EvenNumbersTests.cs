using LinqQuiz.QuizCollection;
using System;
using Xunit;

namespace LinqQuiz.Test
{
    public class EvenNumbersTests
    {
        [Fact]
        public void CurrectResult()
        {
            Assert.Equal(new[] { 2, 4, 6, 8 }, Quiz.GetEvenNumbers(10));
        }

        [Fact]
        public void EmptyResult()
        {
            Assert.Empty(Quiz.GetEvenNumbers(1));
        }

        [Fact]
        public void InvalidArgument()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Quiz.GetEvenNumbers(0));
        }
    }
}
