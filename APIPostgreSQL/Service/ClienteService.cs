using APIPostgreSQL.Entidades;
using Microsoft.AspNetCore.Http.HttpResults;
using NHibernate;
using NHibernate.SqlCommand;

namespace APIPostgreSQL.Service
{
    public class ClienteService
    {
        private readonly ISessionFactory session;
        public ClienteService(ISessionFactory session)
        {
            this.session = session;
        }


        public bool Criar(Cliente cliente)
        {
            using var sessao = session.OpenSession();
            using var transaction = sessao.BeginTransaction();
            sessao.Save(cliente);
            transaction.Commit();
            return true;
        }

        public bool Editar(Cliente cliente)
        {
            using var sessao = session.OpenSession();
            using var transaction = sessao.BeginTransaction();
            sessao.Merge(cliente);
            transaction.Commit();
            return true;
        }

        public Cliente Excluir(int id)
        {
            using var sessao = session.OpenSession();
            using var transaction = sessao.BeginTransaction();
            var Cliente = sessao.Query<Cliente>().Where(x => x.Id == id).FirstOrDefault();
            if (Cliente == null)
            {
                Console.WriteLine("Cliente não identificado");
                return null;
            }
            sessao.Delete(Cliente);
            transaction.Commit();
            return Cliente;

        }
        public virtual List<Cliente> Listar()
        {
            using var sessao = session.OpenSession();
            var Alunos = sessao.Query<Cliente>().ToList();
            return Alunos;
        }

        public virtual List<Cliente> Listar(string nome)
        {
            using var sessao = session.OpenSession();
            var Cliente = sessao.Query<Cliente>().Where(x => x.Nome.Contains(nome)).OrderBy(x => x.Nome).ToList();
            return Cliente;
        }
    }
}
