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

    // check that a square is valid with a given value
    static bool ValidSquare(int[,] grid, int row, int column, int value){
      // skip if square currently has the given value
      if(grid[row, column] == value){
        return false;
      }

      // value is invalid if it is already in the current row
      for(int i=0; i<9; i++){
        if(grid[row, i] == value){
          return false;
        }
      }

      // value is invalid if it is already in the current column
      for(int i=0; i<9; i++){
        if(grid[i, column] == value){
          return false;
        }
      }

      // value is invalid if it is already in the current 3x3 block
      int _startRow = row - row%3;
      int _startColumn = column - column%3;

      for(int i=0; i<3; i++){
        for(int j=0; j<3; j++){
          if(grid[_startRow+i, _startColumn+j] == value){
            return false;
          }
        }
      }

      return true;
    }

    static bool Solve(int[,] grid, int row, int column){
      // if we are at the end of the grid, we are done
      if(row == 8 && column == 9){
        PrintGrid(grid);
        return true;
      }

      // if we are at the end of the row, go to the next row
      if(column == 9){
        row++;
        column = 0;
      }

      // if the current square is not empty, go to the next square
      if(grid[row, column] != 0){
        return Solve(grid, row, column+1);
      }

      // try each value 1-9
      for(int i=1; i<10; i++){
        if(ValidSquare(grid, row, column, i)){
          grid[row, column] = i;
          if(Solve(grid, row, column+1)){
            return true;
          }
        }
      }

      // if no values have worked, reset the square
      grid[row, column] = 0;
      return false;
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

      Solve(theGrid, 0, 0);
    }
  }
}
