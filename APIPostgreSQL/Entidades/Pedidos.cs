namespace APIPostgreSQL.Entidades
{
    public class Pedidos
    {
        public virtual int Id_Pedido { get; set;}
        public virtual int Id { get; set;}
        public virtual int Valor { get; set;}
        public virtual string Situacao { get; set;}
        public virtual DateTime DataCriacao { get; set;}
        public virtual DateTime DataPagamento { get; set;}
        public virtual string Descricao { get; set;}

    }
}
