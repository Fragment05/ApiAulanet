using ApiAulanet.Contratos;
using ApiAulanet.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace ApiAulanet.DAL
{
    public class ResultadosDAL : IResultados
    {
        private readonly string conexion;

        public ResultadosDAL(IConfiguration config)
        {
            conexion = config.GetConnectionString("DefaultConnection");
        }

        public ResultadoIndividual GetResultadoIndividual(int idUsuario, int idLeccion)
        {
            ResultadoIndividual resultado = new ResultadoIndividual();
            resultado.Preguntas = new List<PreguntaDetalle>();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();

                //Puntaje
                using (SqlCommand cmd = new SqlCommand("sp_PuntajeUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@IdLeccion", idLeccion);

                    object r = cmd.ExecuteScalar();
                    if (r != null)
                        resultado.Puntaje = (int)r;
                }

                //  Mejor puntaje
                using (SqlCommand cmd = new SqlCommand("sp_MejorPuntaje", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdLeccion", idLeccion);

                    object r = cmd.ExecuteScalar();
                    if (r != null && resultado.Puntaje == (int)r)
                        resultado.EsMejorCalificacion = true;
                    else
                        resultado.EsMejorCalificacion = false;
                }

                //  Preguntas
                using (SqlCommand cmd = new SqlCommand("sp_PreguntasDetalle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@IdLeccion", idLeccion);

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        PreguntaDetalle p = new PreguntaDetalle
                        {
                            Pregunta = dr["Pregunta"].ToString(),
                            RespuestaElegida = dr["RespuestaElegida"].ToString(),
                            RespuestaCorrecta = dr["RespuestaCorrecta"].ToString(),
                            EsCorrecta = dr["RespuestaElegida"].ToString() == dr["RespuestaCorrecta"].ToString()
                        };

                        resultado.Preguntas.Add(p);
                    }

                    dr.Close();
                }
            }

            return resultado;
        }

        public List<Ranking> GetRanking(int idLeccion)
        {
            List<Ranking> lista = new List<Ranking>();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Ranking", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdLeccion", idLeccion);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Ranking
                    {
                        NombreUsuario = dr["NombreUsuario"].ToString(),
                        Puntaje = (int)dr["Puntaje"],
                        TiempoSegundos = (int)dr["TiempoSegundos"]
                    });
                }
            }

            return lista;
        }
    }
}