using System.Threading.Tasks;
using ConsumirAPI.Models;

namespace ConsumirAPI.Interfaces
{
    public interface IServicoCepApi
    {
        //Falta API refit REST nuget
        [Get("/ws/{cep}/json/")]
        Task<CepDominio> RetornarEndereco(string cep);
    }
}