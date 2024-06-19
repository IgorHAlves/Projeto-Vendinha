using APIPostgreSQL.Entidades;
using Microsoft.AspNetCore.Http.HttpResults;
using NHibernate;
using NHibernate.Linq;
using NHibernate.SqlCommand;
using System.Collections.Immutable;

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
        public virtual List<ClienteComPedidos> Listar()
        {
            using var sessao = session.OpenSession();
            {
                var query = from cliente in sessao.Query<Cliente>()
                            join pedido in sessao.Query<Pedidos>().Where(x => x.Situacao == "Não pago") on cliente.Id equals pedido.Id into pedidosGroup
                            from pedido in pedidosGroup.DefaultIfEmpty()
                            group pedido by cliente into clienteGroup
                            select new ClienteComPedidos
                            {
                                Cliente = clienteGroup.Key,
                                Divida = clienteGroup.Sum(p => p != null ? p.Valor : 0)
                            };

                return query.ToList();
            }
        }

        public virtual List<ClienteComPedidos> Listar(string nome)
        {
            using var sessao = session.OpenSession();
            {
                var query = from cliente in sessao.Query<Cliente>().Where(x => x.Nome == nome)
                            join pedido in sessao.Query<Pedidos>().Where(x => x.Situacao == "Não pago") on cliente.Id equals pedido.Id into pedidosGroup
                            from pedido in pedidosGroup.DefaultIfEmpty()
                            group pedido by cliente into clienteGroup
                            select new ClienteComPedidos
                            {
                                Cliente = clienteGroup.Key,
                                Divida = clienteGroup.Sum(p => p != null ? p.Valor : 0)
                            };

                return query.ToList();
            }
        }


    }
}
