using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        MenuPrincipal();
    }

    private static void MenuPrincipal()
    {
        Console.WriteLine("Escolha um exemplo para rodar:");
        Console.WriteLine("1) Valor da variável SOMA");
        Console.WriteLine("2) Sequência de Fibonacci");
        Console.WriteLine("3) Faturamento Diário");
        Console.WriteLine("4) Percentual de Representação por Estado");
        Console.WriteLine("5) Inverter String");
        Console.WriteLine("6) Sair");

        int escolha = int.Parse(Console.ReadLine());

        switch (escolha)
        {
            case 1:
                Console.Clear();
                ValorDaVariavelSoma();
                break;
            case 2:
                Console.Clear();
                SequenciaFibonacci();
                break;
            case 3:
                Console.Clear();
                FaturamentoDiario();
                break;
            case 4:
                Console.Clear();
                PercentualRepresentacaoEstado();
                break;
            case 5:
                InverterString();
                Console.Clear();
                break;
            case 6:
                Console.WriteLine("Saindo do programa...");
                Environment.Exit(0); break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    private static void VoltarMenu()
    {
        Console.ReadKey();
        Console.Clear();
        MenuPrincipal();
    }

    static void ValorDaVariavelSoma()
    {
        Console.WriteLine("1) Valor da variável:");
        Console.WriteLine("int INDICE = 13;");
        Console.WriteLine("int SOMA = 0;");
        Console.WriteLine("int K = 0;");

        int INDICE = 13, SOMA = 0, K = 0;

        Console.WriteLine("\nCalculando SOMA com o loop...");

        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
            Console.WriteLine($"K = {K}, SOMA = {SOMA}");
        }

        Console.WriteLine($"O valor da variável SOMA é: {SOMA}");
        VoltarMenu();
    }

    static void SequenciaFibonacci()
    {
        Console.Write("Informe um número: ");
        int numero = int.Parse(Console.ReadLine());

        if (VerificaFibonacci(numero))
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
        else
            Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci.");

        VoltarMenu();
    }

    static bool VerificaFibonacci(int numero)
    {
        int a = 0, b = 1;
        while (b < numero)
        {
            int temp = b;
            b = a + b;
            a = temp;
        }
        return b == numero;
    }

    static void FaturamentoDiario()
    {
        string json = @"
        [
            { ""dia"": 1, ""valor"": 22174.1664 },
            { ""dia"": 2, ""valor"": 24537.6698 },
            { ""dia"": 3, ""valor"": 26139.6134 },
            { ""dia"": 4, ""valor"": 0.0 },
            { ""dia"": 5, ""valor"": 0.0 },
            { ""dia"": 6, ""valor"": 26742.6612 },
            { ""dia"": 7, ""valor"": 0.0 },
            { ""dia"": 8, ""valor"": 42889.2258 },
            { ""dia"": 9, ""valor"": 46251.174 },
            { ""dia"": 10, ""valor"": 11191.4722 },
            { ""dia"": 11, ""valor"": 0.0 },
            { ""dia"": 12, ""valor"": 0.0 },
            { ""dia"": 13, ""valor"": 3847.4823 },
            { ""dia"": 14, ""valor"": 373.7838 },
            { ""dia"": 15, ""valor"": 2659.7563 },
            { ""dia"": 16, ""valor"": 48924.2448 },
            { ""dia"": 17, ""valor"": 18419.2614 },
            { ""dia"": 18, ""valor"": 0.0 },
            { ""dia"": 19, ""valor"": 0.0 },
            { ""dia"": 20, ""valor"": 35240.1826 },
            { ""dia"": 21, ""valor"": 43829.1667 },
            { ""dia"": 22, ""valor"": 18235.6852 },
            { ""dia"": 23, ""valor"": 4355.0662 },
            { ""dia"": 24, ""valor"": 13327.1025 },
            { ""dia"": 25, ""valor"": 0.0 },
            { ""dia"": 26, ""valor"": 0.0 },
            { ""dia"": 27, ""valor"": 25681.8318 },
            { ""dia"": 28, ""valor"": 1718.1221 },
            { ""dia"": 29, ""valor"": 13220.495 },
            { ""dia"": 30, ""valor"": 8414.61 }
        ]";

        var faturamentos = JsonConvert.DeserializeObject<List<dynamic>>(json);

        foreach (var faturamento in faturamentos)
        {
            Console.WriteLine($"Dia: {faturamento.dia}, Valor: {faturamento.valor:F2}");
        }

        double menorFaturamento = faturamentos
            .Where(f => (double)f.valor > 0)
            .Min(f => (double)f.valor);

        double maiorFaturamento = faturamentos.Max(f => (double)f.valor);

        double mediaFaturamento = faturamentos
            .Where(f => (double)f.valor > 0)
            .Average(f => (double)f.valor);

        int diasAcimaDaMedia = faturamentos.Count(f => (double)f.valor > mediaFaturamento);

        Console.WriteLine($"Menor valor de faturamento: R${menorFaturamento:F2}");
        Console.WriteLine($"Maior valor de faturamento: R${maiorFaturamento:F2}");
        Console.WriteLine($"Número de dias com faturamento superior à média: {diasAcimaDaMedia}");
        VoltarMenu();
    }

    static void PercentualRepresentacaoEstado()
    {
        var faturamentoEstado = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        Console.WriteLine("Faturamento por Estado:");
        foreach (var estado in faturamentoEstado)
        {
            Console.WriteLine($"{estado.Key}: R${estado.Value:F2}");
        }

        Console.WriteLine();
        double faturamentoTotal = 0;
        foreach (var valor in faturamentoEstado.Values)
        {
            faturamentoTotal += valor;
        }

        Console.WriteLine("Percentual de Representação de Cada Estado:");
        foreach (var estado in faturamentoEstado)
        {
            double percentual = (estado.Value / faturamentoTotal) * 100;
            Console.WriteLine($"{estado.Key}: {percentual:F2}%");
        }

        VoltarMenu();
    }

    static void InverterString()
    {
        Console.Write("Digite uma string para inverter: ");
        string texto = Console.ReadLine();
        Console.WriteLine($"String invertida: {InverterStringManual(texto)}");
        VoltarMenu();
    }

    static string InverterStringManual(string texto)
    {
        char[] caracteres = texto.ToCharArray();

        int inicio = 0;
        int fim = caracteres.Length - 1;

        while (inicio < fim)
        {
            char caractereTemp = caracteres[inicio];

            caracteres[inicio] = caracteres[fim];
            caracteres[fim] = caractereTemp;

            inicio++;
            fim--;
        }

        return new (caracteres);
    }
}

