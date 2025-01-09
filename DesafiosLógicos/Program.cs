using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Console.WriteLine("Escolha um exemplo para rodar:");
        Console.WriteLine("1) Valor da variável SOMA");
        Console.WriteLine("2) Sequência de Fibonacci");
        Console.WriteLine("3) Faturamento Diário");
        Console.WriteLine("4) Percentual de Representação por Estado");
        Console.WriteLine("5) Inverter String");

        int escolha = int.Parse(Console.ReadLine());

        switch (escolha)
        {
            case 1:
                ValorDaVariavelSoma();
                break;
            case 2:
                SequenciaFibonacci();
                break;
            case 3:
                FaturamentoDiario();
                break;
            case 4:
                PercentualRepresentacaoEstado();
                break;
            case 5:
                InverterString();
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    static void ValorDaVariavelSoma()
    {
        int INDICE = 13, SOMA = 0, K = 0;
        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }
        Console.WriteLine($"O valor da variável SOMA é: {SOMA}");
    }

    static void SequenciaFibonacci()
    {
        Console.Write("Informe um número: ");
        int numero = int.Parse(Console.ReadLine());

        if (VerificaFibonacci(numero))
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
        else
            Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci.");
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
            { ""dia"": 9, ""faturamento"": 12345.67 }
        ]";

        var faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(json);

        var diasComFaturamento = faturamentos.Where(f => f.ValorFaturamento > 0).ToList();

        double menorFaturamento = diasComFaturamento.Min(f => f.ValorFaturamento);
        double maiorFaturamento = diasComFaturamento.Max(f => f.ValorFaturamento);

        double mediaFaturamento = diasComFaturamento.Average(f => f.ValorFaturamento);

        int diasAcimaDaMedia = diasComFaturamento.Count(f => f.ValorFaturamento > mediaFaturamento);

        Console.WriteLine($"Menor valor de faturamento: R${menorFaturamento:F2}");
        Console.WriteLine($"Maior valor de faturamento: R${maiorFaturamento:F2}");
        Console.WriteLine($"Número de dias com faturamento superior à média: {diasAcimaDaMedia}");
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

        double faturamentoTotal = 0;
        foreach (var valor in faturamentoEstado.Values)
        {
            faturamentoTotal += valor;
        }

        foreach (var estado in faturamentoEstado)
        {
            double percentual = (estado.Value / faturamentoTotal) * 100;
            Console.WriteLine($"{estado.Key}: {percentual:F2}%");
        }
    }

    static void InverterString()
    {
        Console.Write("Digite uma string para inverter: ");
        string texto = Console.ReadLine();
        Console.WriteLine($"String invertida: {InverterStringManual(texto)}");
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
class Faturamento
{
    public int Dia { get; set; }
    public double ValorFaturamento { get; set; }
}
