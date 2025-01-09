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
            { ""dia"": 1, ""faturamento"": 67836.43 },
            { ""dia"": 2, ""faturamento"": 36678.66 },
            { ""dia"": 3, ""faturamento"": 29229.88 },
            { ""dia"": 4, ""faturamento"": 27165.48 },
            { ""dia"": 5, ""faturamento"": 19849.53 },
            { ""dia"": 6, ""faturamento"": 0 },
            { ""dia"": 7, ""faturamento"": 0 },
            { ""dia"": 8, ""faturamento"": 34567.00 },
            { ""dia"": 9, ""faturamento"": 12345.67 },
            { ""dia"": 10, ""faturamento"": 15000.00 },
            { ""dia"": 11, ""faturamento"": 45235.89 },
            { ""dia"": 12, ""faturamento"": 30567.44 },
            { ""dia"": 13, ""faturamento"": 48960.12 },
            { ""dia"": 14, ""faturamento"": 28945.33 },
            { ""dia"": 15, ""faturamento"": 10234.56 },
            { ""dia"": 16, ""faturamento"": 22222.22 },
            { ""dia"": 17, ""faturamento"": 39478.13 },
            { ""dia"": 18, ""faturamento"": 16000.77 },
            { ""dia"": 19, ""faturamento"": 41323.44 },
            { ""dia"": 20, ""faturamento"": 29567.12 }
        ]";

        var faturamentos = JsonConvert.DeserializeObject<List<dynamic>>(json);

        foreach (var faturamento in faturamentos)
        {
            Console.WriteLine($"Dia: {faturamento.dia}, Faturamento: {faturamento.faturamento:F2}");
        }

        double menorFaturamento = faturamentos
            .Where(f => (double)f.faturamento > 0)
            .Min(f => (double)f.faturamento);

        double maiorFaturamento = faturamentos.Max(f => (double)f.faturamento);

        double mediaFaturamento = faturamentos.Average(f => (double)f.faturamento);

        int diasAcimaDaMedia = faturamentos.Count(f => (double)f.faturamento > mediaFaturamento);

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

public class Faturamento
{
    public int Dia { get; set; }
    public double ValorFaturamento { get; set; }
}
