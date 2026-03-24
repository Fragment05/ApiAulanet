using System.Collections.Generic;
using ApiAulanet.Entities;

namespace ApiAulanet.Contratos
{
    public interface IResultados
    {
        ResultadoIndividual GetResultadoIndividual(int idUsuario, int idLeccion);
        List<Ranking> GetRanking(int idLeccion);
    }
}
