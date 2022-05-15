using LocadoraCarros.Entities;
using LocadoraCarros.Services;
using System;
using System.Globalization;


namespace LocadoraCarros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do alugel: ");
            Console.Write("Modelo do carro: ");
            string modelo = Console.ReadLine();
            Console.Write("Data e horário de retirada (DD/MM/YYYY) hh:mm : ");
            DateTime inicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Data e horário de retorno (DD/MM/YYYY) hh:mm : ");
            DateTime fim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Preço por hora: ");
            double valorPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Preço por dia: ");
            double valorPorDia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            AluguelCarro aluguelCarro = new AluguelCarro(inicio,fim, new Veiculo(modelo));

            ServicoAluguel serviçoAluguel = new ServicoAluguel(valorPorHora, valorPorDia, new ServicoTaxaBrasil());

            serviçoAluguel.ProcessarFatura(aluguelCarro);

            Console.WriteLine();
            Console.WriteLine("FATURA:");
            Console.WriteLine(aluguelCarro.Fatura);

        }
    }
}
