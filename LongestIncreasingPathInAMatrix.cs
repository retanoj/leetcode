using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode
{
    class LongestIncreasingPathInAMatrix
    {
        
        void LongStep(int[,] matrix, int[,] stepMatrix, int row, int col)
        {
            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);
            int cnt = 0;    
                
            //go left
            if (col - 1 >= 0 && 
                matrix[row, col] < matrix[row, col-1])
            {
                if (stepMatrix[row, col - 1] == 0) { LongStep(matrix, stepMatrix, row, col - 1); }
                if (cnt < stepMatrix[row, col - 1]) { cnt = stepMatrix[row, col - 1]; }
            }
            //go right
            if (col + 1 < colLen &&
                matrix[row, col] < matrix[row, col + 1])
            {
                if (stepMatrix[row, col + 1] == 0) { LongStep(matrix, stepMatrix, row, col + 1); }
                if (cnt < stepMatrix[row, col + 1]) { cnt = stepMatrix[row, col + 1]; }
            }
            //go up
            if (row - 1 >= 0 && 
                matrix[row, col] < matrix[row-1, col])
            {
                if (stepMatrix[row - 1, col] == 0) { LongStep(matrix, stepMatrix, row - 1, col); }
                if (cnt < stepMatrix[row - 1, col]) { cnt = stepMatrix[row - 1, col]; }
            }
            //go down
            if (row + 1 < rowLen &&
                matrix[row, col] < matrix[row+1, col])
            {
                if (stepMatrix[row + 1, col] == 0) { LongStep(matrix, stepMatrix, row + 1, col); }
                if (cnt < stepMatrix[row + 1, col]) { cnt = stepMatrix[row + 1, col]; }
            }

            stepMatrix[row, col] = cnt + 1;
        }

        bool couldPush(int[,] matrix, int row, int col)
        {
            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);

            if (row - 1 >= 0 && matrix[row - 1, col] < matrix[row, col]) { return false; }
            if (row + 1 < rowLen && matrix[row + 1, col] < matrix[row, col]) { return false; }
            if (col - 1 >= 0 && matrix[row, col - 1] < matrix[row, col]) { return false; }
            if (col + 1 < colLen && matrix[row, col + 1] < matrix[row, col]) { return false; }
            return true;

        }

        public int LongestIncreasingPath(int[,] matrix)
        {
            int rowNum = matrix.GetLength(0);
            int colNum = matrix.GetLength(1);
            int[,] stepMatrix = new int[rowNum, colNum];
            int result = 0;

            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    if (couldPush(matrix, i, j))
                    {
                        LongStep(matrix, stepMatrix, i, j);
                        if (stepMatrix[i, j] > result) { result = stepMatrix[i, j]; }
                    }
                }
            }
            return result;
        }
    }
}
