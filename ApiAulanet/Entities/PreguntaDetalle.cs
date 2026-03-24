namespace ApiAulanet.Entities
{
    public class PreguntaDetalle
    {
        public string Pregunta { get; set; }
        public string RespuestaElegida { get; set; }
        public string RespuestaCorrecta { get; set; }
        public bool EsCorrecta { get; set; }
    }
}
