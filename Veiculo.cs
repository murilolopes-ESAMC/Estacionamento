namespace Estacionamento;

public class Veiculo
{
    public string Placa { get; private set; } = string.Empty;
    public string Modelo { get; private set; } = string.Empty;
    public DateTime HorarioEntrada { get; private set; }
    public DateTime? HorarioSaida { get; set; }
    public decimal ValorPago { get; set; }

    public Veiculo()
    {
    }

    public Veiculo(string placa, string modelo, DateTime horarioEntrada)
    {
        Placa = placa;
        Modelo = modelo;
        HorarioEntrada = horarioEntrada;
    }

    public void CalculaValor(DateTime horarioSaida)
    {
        HorarioSaida = horarioSaida;
        if (horarioSaida - HorarioEntrada < TimeSpan.FromHours(1))
        {
            ValorPago = 10;
            return;
        }
        else
        {
            ValorPago = (decimal)(HorarioSaida.Value - HorarioEntrada).TotalHours * 10;
            return;
        }
    }

    public void MostraDados()
    {
        Console.WriteLine($"Placa: {Placa}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Horário de Entrada: {HorarioEntrada:HH:mm}");
        if (HorarioSaida.HasValue)
        {
            Console.WriteLine($"Horário de Saída: {HorarioSaida.Value:HH:mm}");
            Console.WriteLine($"Valor Pago: R$ {ValorPago:F2}");
        }
        else
        {
            Console.WriteLine("O veículo ainda não saiu do estacionamento.");
        }
    }


}

