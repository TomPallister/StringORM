﻿namespace StringORM.Infrastructure.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal SafeDivision(this decimal numerator, decimal denominator)
        {
            return (denominator == 0) ? 0 : numerator/denominator;
        }
    }
}