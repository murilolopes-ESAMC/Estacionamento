using Estacionamento;

List<Veiculo> veiculos = new List<Veiculo>();
bool exibirMenu = true;

while (exibirMenu)
{
    Console.WriteLine("Projeto Estacionamento iniciado.");
    Console.WriteLine("Escolha uma das opções abaixo:");
    Console.WriteLine("1. Registrar entrada de veículo");
    Console.WriteLine("2. Registrar saída de veículo");
    Console.WriteLine("3. Mostrar dados do veículo");
    Console.WriteLine("0. Sair");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Digite a placa do veículo:");
            string placa = Console.ReadLine() ?? string.Empty;
            if (veiculos.Any(v => v.Placa == placa))
            {
                Console.WriteLine("Veículo já registrado no estacionamento.");
                break;
            }
            Console.WriteLine("Digite o modelo do veículo:");
            string modelo = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Digite o horário de entrada (formato: HH:mm):");

            string entradaTexto = Console.ReadLine() ?? string.Empty;
            if (TimeSpan.TryParse(entradaTexto, out TimeSpan horaEntrada))
            {
                DateTime horarioEntrada = DateTime.Today.Add(horaEntrada);
                Veiculo veiculoEntrada = new Veiculo(placa, modelo, horarioEntrada);
                veiculos.Add(veiculoEntrada);
                Console.WriteLine("Entrada de veículo registrada com sucesso.");
            }
            else
            {
                Console.WriteLine("Horário de entrada inválido! Use o formato HH:mm (ex: 08:30).");
            }
            break;

        case "2":
            Console.WriteLine("Digite a placa do veículo para registrar a saída:");
            string placaSaida = Console.ReadLine() ?? string.Empty;

            Veiculo? veiculoSaida = veiculos.FirstOrDefault(v => v.Placa == placaSaida);
            if (veiculoSaida != null)
            {
                Console.WriteLine("Digite o horário de saída (formato: HH:mm):");
                string saidaTexto = Console.ReadLine() ?? string.Empty;

                if (TimeSpan.TryParse(saidaTexto, out TimeSpan horaSaida))
                {
                    DateTime horarioSaida = DateTime.Today.Add(horaSaida);
                    veiculoSaida.CalculaValor(horarioSaida);
                    Console.WriteLine("Saída de veículo registrada com sucesso.");
                    veiculoSaida.MostraDados();
                }
                else
                {
                    Console.WriteLine("Horário de saída inválido! Use o formato HH:mm (ex: 14:30).");
                }
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
            break;

        case "3":
            Console.WriteLine("Digite a placa do veículo para mostrar os dados:");
            string placaConsulta = Console.ReadLine() ?? string.Empty;

            Veiculo? veiculoConsulta = veiculos.FirstOrDefault(v => v.Placa == placaConsulta);
            if (veiculoConsulta != null)
            {
                veiculoConsulta.MostraDados();
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }
            break;

        case "0":
            Console.WriteLine("Encerrando o programa.");
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

