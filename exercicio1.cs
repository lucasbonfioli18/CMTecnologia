using System;

class DiagonalInverter
{
    static void Main()
    {
        // Inicialização da variável de repetição para inversão de múltiplas matrizes.
        bool repeat = true;
        while (repeat)
        {
            // Usuário insere a ordem da matriz quadrada desejada, que também serve como validação para ser sempre uma matriz quadrada.
            int tamanho = ObterTamanhoDaMatrizDoUsuario();

            var matriz = CriarMatriz(tamanho);

            PreencherMatriz(matriz, tamanho);

            InverterDiagonais(matriz, tamanho);

            ExibirMatriz(matriz, tamanho);

            repeat = PerguntarSeRepete();
        }
    }

    // Obtém o tamanho da matriz quadrada do usuário e trata a entrada, exigindo um número inteiro positivo.
    static int ObterTamanhoDaMatrizDoUsuario()
    {
        int tamanho;
        while (true)
        {
            Console.Write("Informe o tamanho da matriz: ");
            if (int.TryParse(Console.ReadLine(), out tamanho) && tamanho > 0)
                break;
            else
                Console.WriteLine("Entrada inválida. Por favor, informe um número inteiro positivo.");
        }
        return tamanho;
    }

    // Cria a matriz com base no tamanho informado pelo usuário.
    static double[,] CriarMatriz(int tamanho)
    {
        double[,] matriz = new double[tamanho, tamanho];
        return matriz;
    }

    // Preenche a matriz com os valores informados pelo usuário.
    static void PreencherMatriz(double[,] matriz, int tamanho)
    {
        Console.WriteLine("Informe os valores da matriz:");
        for (int i = 0; i < tamanho; i++)
        {
            for (int j = 0; j < tamanho; j++)
            {
                Console.Write("Informe o valor para [{0}, {1}]: ", i, j);
                matriz[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }

    // Inverte as diagonais da matriz utilizando uma lógica aritmética.
    static void InverterDiagonais(double[,] matriz, int tamanho)
    {
        for (int i = 0; i < tamanho; i++)
        {
            double temp = matriz[i, i];
            matriz[i, i] = matriz[i, tamanho - i - 1];
            matriz[i, tamanho - i - 1] = temp;
        }
    }

    // Exibe a matriz invertida para o usuário.
    static void ExibirMatriz(double[,] matriz, int tamanho)
    {
        Console.WriteLine("Matriz invertida:");
        for (int i = 0; i < tamanho; i++)
        {
            for (int j = 0; j < tamanho; j++)
            {
                Console.Write(matriz[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Pergunta ao usuário se deseja repetir o processo para outra matriz.
    static bool PerguntarSeRepete()
    {
        while (true)
        {
            Console.Write("Deseja inverter outra matriz? (S/N): ");
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
