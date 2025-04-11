using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class SquareMatrixExtensions : SquareMatrix {
  public SquareMatrixExtensions(int[,] matrix) : base(matrix) {
  }

  public SquareMatrixExtensions(int size) : base(size) {
  }

  public SquareMatrixExtensions(int size, Random random) : base(size, random) {
  }

  public void TransposeMatrix(SquareMatrixExtensions a) {
    Random random = new Random();
    SquareMatrixExtensions result = new SquareMatrixExtensions(a.Size, random);
    for (int countOfLines = 0; countOfLines < Size; ++countOfLines) {
      for (int countOfColumns = 0; countOfColumns < Size; ++countOfColumns) {
        result.matrix[countOfLines, countOfColumns] = this.matrix[countOfColumns, countOfLines];
      }
    }
    Console.WriteLine(result);
  }

  public int Track(SquareMatrixExtensions a) {
    int result = 0;
    for (int countOfLinesAndColumns = 0; countOfLinesAndColumns < Size; ++countOfLinesAndColumns) {
      result += a.matrix[countOfLinesAndColumns, countOfLinesAndColumns];
    }
    return result;
  }

  public SquareMatrixExtensions InvertMatrix() {
    int det = this.Determinant();
    SquareMatrixExtensions result = new SquareMatrixExtensions(this.matrix);
    for (int countOfLines = 0; countOfLines < Size; ++countOfLines) {
      for (int countOfColumns = 0; countOfColumns < Size; ++countOfColumns) {
        result.matrix[countOfLines, countOfColumns] /= det;
      }
    }
    return result;
  }
  // Делегат для преобразования матрицы
  public delegate SquareMatrixExtensions MatrixTransformer(SquareMatrixExtensions matrix); // в дальнейшем будет доработано, а пока - заглушка

  // Пример использования анонимного метода
  public MatrixTransformer diagonalize = delegate (SquareMatrixExtensions m)
  {
    int[,] diagonal = new int[m.Size, m.Size];
    for (int countOfLinesAndColumns = 0; countOfLinesAndColumns < m.Size; ++countOfLinesAndColumns) {
      diagonal[countOfLinesAndColumns, countOfLinesAndColumns] = m.matrix[countOfLinesAndColumns, countOfLinesAndColumns]; 
    }
    SquareMatrixExtensions result = new SquareMatrixExtensions(diagonal);
    Console.WriteLine(result);
    return result;
  };
}