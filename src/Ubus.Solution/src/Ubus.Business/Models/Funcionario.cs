namespace Ubus.Business.Models
{
    public abstract class Funcionario : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
    }
}
