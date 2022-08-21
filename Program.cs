using System;

namespace cs_sudoku_solver
{
  class Program
  {
    static string[,] StringGrid(int[,] grid){
      string[,] newGrid = new string[9,9];
      for (int row = 0; row<9; row++)
      {
        for (int column = 0; column<9; column++)
        {
          newGrid[row, column] = grid[row, column].ToString();
        }
      }
      return newGrid;
    }

    static void PrintGrid(int[,] grid){
      for(int i=0; i<9; i++){
        for(int j=0; j<9; j++){
          Console.Write(grid[i,j]);
        }
        Console.Write("\n");
      }
    }

    static void Main(string[] args)
    {
      int[,] theGrid = {
        {3, 0, 6, 5, 0, 8, 0, 0, 0},
        {5, 2, 0, 0, 0, 0, 0, 0, 0},
        {0, 8, 7, 0, 0, 0, 0, 3, 1},
        {0, 0, 3, 0, 1, 0, 0, 8, 0},
        {9, 0, 0, 8, 6, 3, 0, 0, 5},
        {0, 5, 0, 0, 9, 0, 6, 0, 0},
        {1, 3, 0, 0, 0, 0, 2, 5, 0},
        {0, 0, 0, 0, 0, 0, 0, 7, 4},
        {0, 0, 5, 2, 0, 6, 3, 0, 0}
      };

      int[,] theGridReference = {
        {3, 0, 6, 5, 0, 8, 0, 0, 0},
        {5, 2, 0, 0, 0, 0, 0, 0, 0},
        {0, 8, 7, 0, 0, 0, 0, 3, 1},
        {0, 0, 3, 0, 1, 0, 0, 8, 0},
        {9, 0, 0, 8, 6, 3, 0, 0, 5},
        {0, 5, 0, 0, 9, 0, 6, 0, 0},
        {1, 3, 0, 0, 0, 0, 2, 5, 0},
        {0, 0, 0, 0, 0, 0, 0, 7, 4},
        {0, 0, 5, 2, 0, 6, 3, 0, 0}
      };

      PrintGrid(theGrid);
    }
  }
}
