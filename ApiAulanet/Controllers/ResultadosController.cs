using ApiAulanet.Contratos;
using ApiAulanet.DAL;
using ApiAulanet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ApiAulanet.Controllers
{
    [ApiController]
    [Route("api/resultados")]
    public class ResultadosController : ControllerBase
    {
        private readonly IResultados datos;

        public ResultadosController(IConfiguration config)
        {
            datos = new ResultadosDAL(config);
        }

        //  ENDPOINT BASE
        // URL: api/resultados
        [HttpGet("test")]
        public string Test()
        {
            return "API funcionando";
        }

        // ENDPOINT: INDIVIDUAL
        // URL: api/resultados/individual?idUsuario=1&idLeccion=2
        [HttpGet("individual")]
        public ActionResult<ResultadoIndividual> GetIndividual(int idUsuario, int idLeccion)
        {
            var resultado = datos.GetResultadoIndividual(idUsuario, idLeccion);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        //  ENDPOINT: RANKING GRUPAL
        // URL: api/resultados/ranking?idLeccion=2
        [HttpGet("ranking")]
        public ActionResult<List<Ranking>> GetRanking(int idLeccion)
        {
            var lista = datos.GetRanking(idLeccion);

            if (lista == null || lista.Count == 0)
                return NotFound();

            return Ok(lista);
        }
    }
}