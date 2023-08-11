using Flight.Core.Entities;

namespace Flight.Core.Services;

public class VooService : IVooService
{

    private List<Voo> flights = new();
    private List<Passageiro> passageiros = new();
    private int Counter;
    private int passageiroCounter;
    
    public void AdicionaVoo(string origem, string destino, DateTime data, int QuantidadePassagem)
    {
        var novoVoo = new Voo
        {
            Id=Counter++,
            Origem=origem,
            Destino=destino, 
            Data = data
        };
        flights.Add(novoVoo);
    }

    public List<Voo> GetVoos()
    {
        return flights;
    }

    public void Comprar(int vooId, string nomePassageiro)
    {
        
        var flight = flights.FirstOrDefault(f => f.Id == vooId);
        if (flight != null)
        {
            
            var passageiro = passageiros.FirstOrDefault(p => p.Nome == nomePassageiro);
            if (passageiro == null)
            {
                passageiro = new Passageiro
                {
                    Id= passageiroCounter++,
                    Nome = nomePassageiro,
                    QuantidadePassagem = 1
                };
                passageiros.Add(passageiro);
            }
            else
            {
                passageiro.QuantidadePassagem++;
            }
        }

    }

    public List<Passageiro> GetPassageiros(string Nome)
    {
        return passageiros.Where(p => p.Nome == Nome).ToList();
    }
} 