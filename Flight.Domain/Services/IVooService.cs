using Flight.Core.Entities;

namespace Flight.Core.Services;

public interface IVooService
{
    public void AdicionaVoo(string origem, string destino, DateTime data, int QuantidadePassagem);
    public List<Voo> GetVoos();
    public void Comprar(int vooId, string nomePassageiro);
    public List<Passageiro> GetPassageiros(string Nome);
    
}