namespace Flight.Core.Entities;

public class Voo
{
    public int Id { get; set; }
    public string Origem { get; set; }
    public string Destino{ get; set; }
    public DateTime Data { get; set; }
}