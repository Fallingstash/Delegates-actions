using System;

class Program {
  static void Main(string[] args) {

    try {
      Console.WriteLine("Добро пожаловать в калькулятор матриц!!! Пожалуйста, выберите операцию:");
      Console.WriteLine("1. Операции с двумя матрицами");
      Console.WriteLine("2. Операции с одной матрицей");

      Random random = new Random();
      string userAnswer = Console.ReadLine();
      SquareMatrixExtensions matrixA = new SquareMatrixExtensions();

      switch (userAnswer) {
        case "1":
          OperationsWith2Matrix(matrixA);
          break;
        case "2":
          OperationsWith1Matrix(matrixA);
          break;
        default:
          Console.WriteLine("Неверный выбор, попробуйте заново");
          break;
      }
    }
    catch (MatrixSizeException ex) {
      Console.WriteLine(ex.Message);
    }

    void OperationsWith2Matrix(SquareMatrixExtensions matrixA) {
      Random random = new Random();
      Console.Write("Введите размер первой матрицы:");
      int sizeA = Convert.ToInt32(Console.ReadLine());
      Console.Write("Введите размер второй матрицы:");
      int sizeB = Convert.ToInt32(Console.ReadLine());
      matrixA = new SquareMatrixExtensions(sizeA, random);
      SquareMatrix matrixB = new SquareMatrix(sizeB, random);
      Console.WriteLine("Матрица А");
      Console.WriteLine(matrixA);
      Console.WriteLine("Матрица Б");
      Console.WriteLine(matrixB);
      Console.WriteLine("1. Сложить две матрицы.");
      Console.WriteLine("2. Умножить матрицу А на Б");
      Console.WriteLine("3. Сравнить две матрицы");

      string userChoice = Console.ReadLine();
      if (userChoice == "1") {
        Console.WriteLine("Вы выбрали сложение двух матриц");
        Console.WriteLine(matrixA + matrixB);
      } else if (userChoice == "2") {
        Console.WriteLine("Вы выбрали умножение матрицы А на Б");
        Console.WriteLine(matrixA * matrixB);
      } else if (userChoice == "3") {
        Console.WriteLine("Вы выбрали сравнение матриц");
        Console.WriteLine(matrixA == matrixB ? "А = Б" : "А != Б");
        Console.WriteLine(matrixA > matrixB ? "А > Б" : "А <= Б");
      } else {
        Console.WriteLine("Неверный выбор");
      }
    }

    void OperationsWith1Matrix(SquareMatrixExtensions matrixA) {
      Random random = new Random();
      Console.Write("Введите размер матрицы:");
      int size = Convert.ToInt32(Console.ReadLine());
      matrixA = new SquareMatrixExtensions(size, random);
      Console.WriteLine(matrixA);
      Console.WriteLine("1. Выполнить проверку на матрицу(нулевая/не нулевая).");
      Console.WriteLine("2. Создать клон матрицы.");
      Console.WriteLine("3. Найти определитель матрицы.");
      Console.WriteLine("4. Транспонировать");
      Console.WriteLine("5. Вычислить след матрицы");
      Console.WriteLine("6. Построить диагональную матрицу");

      string userChoice = Console.ReadLine();
      if (userChoice == "1") {
        Console.WriteLine("Вы выбрали проверку матрицы");
        Console.WriteLine(matrixA ? "Это ненулевая матрица" : "Это нулевая матрица");
      } else if (userChoice == "2") {
        Console.WriteLine("Вы выбрали создать клон матрицы");
        Console.WriteLine("Клон вашей матрицы:");
        SquareMatrix clone = matrixA.DeepClone();
        Console.WriteLine(clone);
      } else if (userChoice == "3") {
        Console.WriteLine("Вы выбрали найти определитель матрицы");
        Console.WriteLine(matrixA.Determinant());
      } else if (userChoice == "4") {
        Console.WriteLine("Вы выбрали транспонирование матрицы");
        matrixA.TransposeMatrix(matrixA);
      } else if (userChoice == "5") {
        Console.WriteLine("Вы выбрали нахождение следа матрицы");
        Console.Write($"Он равен: {matrixA.Track(matrixA)}");
      } else if (userChoice == "6") {
        Console.WriteLine("Вы выбрали построить диагональную мтарицу.");
        matrixA.diagonalize(matrixA);
        SquareMatrixExtensions result = matrixA.diagonalize(matrixA);
        Console.WriteLine(result);
      }
    }
  }
}