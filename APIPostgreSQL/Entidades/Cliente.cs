namespace APIPostgreSQL.Entidades
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual string Email { get; set; }
        public virtual int Divida { get; set; }
    }
}
