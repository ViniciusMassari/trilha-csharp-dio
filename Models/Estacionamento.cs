
namespace fundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial, precoPorHora;
        private List<string> veiculosEstacionados;
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculosEstacionados = new List<string>();
        }


        public void ListarVeiculos()
        {
            if (!veiculosEstacionados.Any())
            {
                Console.WriteLine("Não há veículos cadastrados !");
                return;
            }
            foreach (string placa in veiculosEstacionados)
            {
                Console.WriteLine(placa);
                return;
            }
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa");
            string? placa = Console.ReadLine();

            if (!string.IsNullOrEmpty(placa))
            {
                veiculosEstacionados.Add(placa);
                Console.WriteLine("Veículo adicionado !");
                return;
            }
            else
            {
                Console.WriteLine("Valores vazios não serão aceitos, tente Novamente");
                AdicionarVeiculo();
            }
        }


        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa");
            string? placa = Console.ReadLine();
            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Valor inválido, tente novamente");
                RemoverVeiculo();
            }

            string veiculoParaRemover = "";
            foreach (string placaVeiculo in veiculosEstacionados)
            {
                if (placaVeiculo == placa)
                {
                    veiculoParaRemover = placaVeiculo;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(veiculoParaRemover))
            {
                Console.WriteLine("Por quantas horas o veículo permaneceu estacionado ?");
                string? horasString = Console.ReadLine();

                if (!string.IsNullOrEmpty(horasString) && int.TryParse(horasString, out int horas))
                {
                    decimal valorASerPago = precoInicial + (horas * precoPorHora);
                    Console.WriteLine("O valor a ser pago é: " + valorASerPago);
                    veiculosEstacionados.Remove(veiculoParaRemover);
                    return;
                }

            }
            else
            {
                Console.WriteLine("Veículo não encontrado !");
                return;
            }
        }
    }
}