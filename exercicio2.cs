using System;

class SubmatrixCounter
{
    static void Main()
    {
        bool repeat = true;
        while (repeat)
        {
            double[,] matrixA = GetMatrixFromUser("A");
            PopulateMatrix(matrixA, "A"); // Preenche a matriz A com os valores informados pelo usuário.

            double[,] submatrixB = GetMatrixFromUser("B");
            bool validB = false;
            do
            {
                validB = IsSubmatrixValid(matrixA, submatrixB);

                if (!validB)
                {
                    Console.WriteLine("\nSubmatriz B deve ser menor que, ou igual, a matriz A em tamanho.");
                    bool tryAgain = AskToTryAgain();
                    if (!tryAgain)
                    {
                        repeat = false;
                        break;
                    }
                    submatrixB = GetMatrixFromUser("B");
                }
            } while (!validB);

            PopulateMatrix(submatrixB, "B"); // Preenche a submatriz B com os valores informados pelo usuário.

            if (!repeat)
                break;

            int count = CountSubmatrixOccurrences(matrixA, submatrixB);

            Console.WriteLine("\nA submatriz B ocorre {0} vez(es) na matriz A.", count);

            repeat = AskToRepeat();
        }
    }

    // Coleta o número de linhas e colunas das matrizes.
    static double[,] GetMatrixFromUser(string matrixName)
    {
        Console.WriteLine($"\nInforme a matriz {matrixName}:");
        int rows = GetValidPositiveInteger("Informe o número de linhas: ");
        int columns = GetValidPositiveInteger("Informe o número de colunas: ");

        double[,] matrix = new double[rows, columns];
        return matrix;
    }

    // Preenche a matriz com os valores informados pelo usuário.
    static void PopulateMatrix(double[,] matrix, string matrixName)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        Console.WriteLine($"\nInforme os valores da matriz {matrixName}:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                bool validInput = false;
                while (!validInput)
                {
                    Console.Write($"Informe o valor para {matrixName} [{i}, {j}]: ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out double value))
                    {
                        matrix[i, j] = value;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, informe um valor numérico.");
                    }
                }
            }
        }
    }

    // Obtém um número inteiro positivo válido informado pelo usuário.
    static int GetValidPositiveInteger(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;
            else
                Console.WriteLine("Entrada inválida. Por favor, informe um número inteiro positivo.");
        }
    }

    // Verifica se a submatriz é válida em relação à matriz principal.
    static bool IsSubmatrixValid(double[,] matrixA, double[,] submatrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = submatrixB.GetLength(0);
        int colsB = submatrixB.GetLength(1);

        return rowsB <= rowsA && colsB <= colsA;
    }

    // Conta o número de ocorrências da submatriz na matriz A.
    static int CountSubmatrixOccurrences(double[,] matrixA, double[,] submatrixB)
    {
        int count = 0;
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int rowsB = submatrixB.GetLength(0);
        int colsB = submatrixB.GetLength(1);

        for (int i = 0; i <= rowsA - rowsB; i++)
        {
            for (int j = 0; j <= colsA - colsB; j++)
            {
                if (IsSubmatrix(matrixA, submatrixB, i, j))
                {
                    count++;
                }
            }
        }

        return count;
    }

    // Verifica se a submatriz B está presente na matriz A em uma determinada posição.
    static bool IsSubmatrix(double[,] matrixA, double[,] submatrixB, int row, int col)
    {
        int rowsB = submatrixB.GetLength(0);
        int colsB = submatrixB.GetLength(1);

        for (int i = 0; i < rowsB; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                if (matrixA[row + i, col + j] != submatrixB[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Pergunta ao usuário se deseja repetir a análise para outro par de matrizes.
    static bool AskToRepeat()
    {
        while (true)
        {
            Console.Write("\nDeseja analisar outro par de matrizes? (S/N): ");
            string input = Console.ReadLine().Trim().ToUpper();
            if (input == "S")
                return true;
            else if (input == "N")
                return false;
            else
                Console.WriteLine("Entrada inválida. Por favor, informe S ou N.");
        }
    }

    // Pergunta ao usuário se deseja inserir novamente a submatriz B.
    static bool AskToTryAgain()
    {
        while (true)
        {
            Console.Write("\nDeseja tentar novamente? (S/N): ");
            string input = Console.ReadLine().Trim().ToUpper();
            if (input == "S")
                return true;
            else if (input == "N")
                return false;
            else
                Console.WriteLine("Entrada inválida. Por favor, informe S ou N.");
        }
    }
}
