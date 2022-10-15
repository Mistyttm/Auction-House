using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionHouse
{
    public static class MultiDimensionalArrayExtensions
{
    public static T[,] OrderBy<T>(this T[,] source, Func<T[], T> keySelector)
    {
        return source.ConvertToSingleDimension().OrderBy(keySelector).ConvertToMultiDimensional();
    }
    
    public static T[,] OrderByDescending<T>(this T[,] source, Func<T[], T> keySelector)
    {
        return source.ConvertToSingleDimension().
            OrderByDescending(keySelector).ConvertToMultiDimensional();
    }
    
    private static IEnumerable<T[]> ConvertToSingleDimension<T>(this T[,] source)
    {
        T[] arRow;
    
        for (int row = 0; row < source.GetLength(0); ++row)
        {
            arRow = new T[source.GetLength(1)];
    
            for (int col = 0; col < source.GetLength(1); ++col)
                arRow[col] = source[row, col];
    
            yield return arRow;
        }
    }
    
    private static T[,] ConvertToMultiDimensional<T>(this IEnumerable<T[]> source)
    {
        T[,] twoDimensional;
        T[][] arrayOfArray;
        int numberofColumns;
    
        arrayOfArray = source.ToArray();
        numberofColumns = (arrayOfArray.Length > 0) ? arrayOfArray[0].Length : 0;
        twoDimensional = new T[arrayOfArray.Length, numberofColumns];
    
        for (int row = 0; row < arrayOfArray.GetLength(0); ++row)
            for (int col = 0; col < numberofColumns; ++col)
                twoDimensional[row, col] = arrayOfArray[row][col];
    
        return twoDimensional;
    }
}
}