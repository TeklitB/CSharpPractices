﻿using System;
using Xunit;
using LinqQuiz.QuizCollection;

namespace LinqQuiz.Test
{
    public class SquaresTests
    {
        [Fact]
        public void CurrectResult()
        {
            Assert.Equal(new[] { 196, 49 }, Quiz.GetSquares(15));
        }

        [Fact]
        public void EmptyResult()
        {
            Assert.Empty(Quiz.GetSquares(7));
            Assert.Empty(Quiz.GetSquares(-1));
        }

        [Fact]
        public void Overflow()
        {
            Assert.Throws<OverflowException>(() => Quiz.GetSquares(47000));
        }
    }
}
