using Microsoft.Extensions.Configuration;
using Mvc_BO.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_BO.Models
{
    public class AlunoBLL : IAlunoBLL
    {
        public void AtualizarAluno(Aluno aluno)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("localDbConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(conexaoString))
                {
                    SqlCommand cmd = new SqlCommand("AtualizarAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@Id";
                    paramId.Value = aluno.Id;
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "@Email";
                    paramEmail.Value = aluno.Email;
                    cmd.Parameters.Add(paramEmail);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramDataInscricao = new SqlParameter();
                    paramDataInscricao.ParameterName = "@Nascimento";
                    paramDataInscricao.Value = aluno.Nascimento;
                    cmd.Parameters.Add(paramDataInscricao);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }
        public List<Aluno> GetAlunos()
        {
            var configuration = ConfigurationHelper.GetConfiguration(Environment.CurrentDirectory);

            var conexaoString = configuration.GetConnectionString("localDbConnection");

            List<Aluno> alunos = new List<Aluno>();

            try
            {
                using(SqlConnection con = new SqlConnection(conexaoString))
                {
                    SqlCommand cmd = new SqlCommand("GetAlunos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Aluno aluno = new Aluno();
                        aluno.Id = Convert.ToInt32(rdr["Id"]);
                        aluno.Nome = rdr["Nome"].ToString();
                        aluno.Email = rdr["Email"].ToString();
                        aluno.Sexo = rdr["Sexo"].ToString();
                        aluno.Nascimento = Convert.ToDateTime(rdr["Nascimento"]);
                        alunos.Add(aluno);
                    }
                    return alunos;
                }
            }catch(Exception e)
            {
                throw;
            }
        }

        public void IncluirAluno(Aluno aluno)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Environment.CurrentDirectory);

            var conexaoString = configuration.GetConnectionString("localDbConnection");

            try
            {
                using(SqlConnection con = new SqlConnection(conexaoString))
                {
                    SqlCommand cmd = new SqlCommand("IncluirAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramNome = new SqlParameter();

                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramEmail = new SqlParameter();

                    paramEmail.ParameterName = "@Email";
                    paramEmail.Value = aluno.Email;
                    cmd.Parameters.Add(paramEmail);

                    SqlParameter paramSexo = new SqlParameter();

                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramNascimento = new SqlParameter();

                    paramNascimento.ParameterName = "@Nascimento";
                    paramNascimento.Value = aluno.Nascimento;
                    cmd.Parameters.Add(paramNascimento);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception e)
            {
                throw;
            }
        }
    }
}
