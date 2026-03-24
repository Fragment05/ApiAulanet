using System.Collections.Generic;
namespace ApiAulanet.Entities
{
    public class ResultadoIndividual
    {
        public int Puntaje { get; set; }
        public bool EsMejorCalificacion { get; set; }
        public List<PreguntaDetalle> Preguntas { get; set; }
    }
}
