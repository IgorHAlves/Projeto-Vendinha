using APIPostgreSQL.Entidades;
using NHibernate;

namespace APIPostgreSQL.Service
{
    public class PedidosService
    {
        private readonly ISessionFactory session;
        public PedidosService(ISessionFactory session)
        {
            this.session = session;
        }

        public bool Criar(Pedidos pedidos)
        {
            using var sessao = session.OpenSession();
            using var transaction = sessao.BeginTransaction();
            sessao.Save(pedidos);
            transaction.Commit();
            return true;
        }
        public bool Editar(Pedidos pedidos)
        {
            using var sessao = session.OpenSession();
            using var transaction = sessao.BeginTransaction();
            sessao.Merge(pedidos);
            transaction.Commit();
            return true;
        }
        public Pedidos Excluir(int id_pedido)
        {
            using var sessao = session.OpenSession();
            using var transaction = sessao.BeginTransaction();
            var Pedidos = sessao.Query<Pedidos>().Where(x => x.Id == id_pedido).FirstOrDefault();
            if (Pedidos == null)
            {
                Console.WriteLine("Cliente não identificado");
                return null;
            }
            sessao.Delete(Pedidos);
            transaction.Commit();
            return Pedidos;

        }
        public virtual List<Pedidos> Listar()
        {
            using var sessao = session.OpenSession();
            var Pedidos = sessao.Query<Pedidos>().ToList();
            return Pedidos;
        }

        public virtual List<Pedidos> Listar(int id)
        {
            using var sessao = session.OpenSession();
            var Pedidos = sessao.Query<Pedidos>().Where(x => x.Id == (id)).OrderBy(x => x.Id_Pedido).ToList();
            return Pedidos;
        }
    }
}
