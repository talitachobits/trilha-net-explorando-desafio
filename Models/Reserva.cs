namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        private const int quantidadeDiasParaObterDesconto = 10;
        private const decimal porcentagemDesconto = 0.1M;

        private bool ElegivelDesconto() => DiasReservados >= quantidadeDiasParaObterDesconto;
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool capacidade = hospedes.Count <= Suite.Capacidade;
            if (capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                 throw new Exception("O número de hóspedes excede a capacidade da suíte!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {       
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (ElegivelDesconto())
            {
                valor *= 1 - porcentagemDesconto;
            }

            return valor;
        }
    }
}