﻿using System;

class Program {
  static void Main(string[] args) {

    try {
      Console.WriteLine("Добро пожаловать в калькулятор матриц!!! Пожалуйста, выберите операцию:");
      Console.WriteLine("1. Операции с двумя матрицами");
      Console.WriteLine("2. Операции с одной матрицей");

      Random random = new Random();
      string userAnswer = Console.ReadLine();
      string userChoice;
      SquareMatrixExtensions a;

      switch (userAnswer) {
        case "1":
          Console.Write("Введите размер первой матрицы:");
          int sizeA = Convert.ToInt32(Console.ReadLine());
          Console.Write("Введите размер второй матрицы:");
          int sizeB = Convert.ToInt32(Console.ReadLine());
          a = new SquareMatrixExtensions(sizeA, random);
          SquareMatrix b = new SquareMatrix(sizeB, random);
          Console.WriteLine("Матрица А");
          Console.WriteLine(a);
          Console.WriteLine("Матрица Б");
          Console.WriteLine(b);
          Console.WriteLine("1. Сложить две матрицы.");
          Console.WriteLine("2. Умножить матрицу А на Б");
          Console.WriteLine("3. Сравнить две матрицы");

          userChoice = Console.ReadLine();
          if (userChoice == "1") {
            Console.WriteLine("Вы выбрали сложение двух матриц");
            Console.WriteLine(a + b);
          }
          else if (userChoice == "2") {
            Console.WriteLine("Вы выбрали умножение матрицы А на Б");
            Console.WriteLine(a * b);

          }
          else if (userChoice == "3") {
            Console.WriteLine("Вы выбрали сравнение матриц");
            Console.WriteLine(a == b ? "А = Б" : "А != Б");
            Console.WriteLine(a > b ? "А > Б" : "А <= Б");
          }
          else {
            Console.WriteLine("Неверный выбор");
            break;
          }
          break;
        case "2":
          Console.Write("Введите размер матрицы:");
          int size = Convert.ToInt32(Console.ReadLine());
          a = new SquareMatrixExtensions(size, random);
          Console.WriteLine(a);
          Console.WriteLine("1. Выполнить проверку на матрицу(нулевая/не нулевая).");
          Console.WriteLine("2. Создать клон матрицы.");
          Console.WriteLine("3. Найти определитель матрицы.");
          Console.WriteLine("4. Транспонировать");
          Console.WriteLine("5. Вычислить след матрицы");
          Console.WriteLine("6. Построить диагональную матрицу");


          userChoice = Console.ReadLine();
          if (userChoice == "1") {
            Console.WriteLine("Вы выбрали проверку матрицы");
            Console.WriteLine(a ? "Это ненулевая матрица" : "Это нулевая матрица");
          }
          else if (userChoice == "2") {
            Console.WriteLine("Вы выбрали создать клон матрицы");
            Console.WriteLine("Клон вашей матрицы:");
            SquareMatrix clone = a.DeepClone();
            Console.WriteLine(clone);
          }
          else if (userChoice == "3") {
            Console.WriteLine("Вы выбрали найти определитель матрицы");
            Console.WriteLine(a.Determinant());
          }
          else if (userChoice == "4") {
            Console.WriteLine("Вы выбрали транспонирование матрицы");
            a.TransposeMatrix(a);
          }
          else if(userChoice == "5") {
            Console.WriteLine("Вы выбрали нахождение следа матрицы");
            Console.Write($"Он равен: {a.Track(a)}");
          }
          else if(userChoice == "6") {
            Console.WriteLine("Вы выбрали построить диагональную мтарицу.");
            a.diagonalize(a);
            SquareMatrixExtensions result = a.diagonalize(a);
            Console.WriteLine(result);
          }
          break;
        default:
          Console.WriteLine("Неверный выбор, попробуйте заново");
          break;
      }
    }
    catch (MatrixSizeException ex) {
      Console.WriteLine(ex.Message);
    }
  }
}