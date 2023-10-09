namespace DesafioProjetoHospedagem.Models
{
     public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; } = new();
        public Suite Suite { get; set; } = new();
        public int DiasReservados { get; set; }

        public Reserva() { }
        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade < hospedes.Count)
                throw new Exception("Capacidade de pessoas não suportada pela suíte, por favor verifique outra unidade.");

            Hospedes = hospedes;
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
            decimal desconto = 0;
            if (DiasReservados >= 10)
                desconto = 10;

            decimal valorBruto = (Suite.ValorDiaria * DiasReservados);
            decimal valorDesconto = valorBruto * (desconto / 100);
            decimal valorLiquido = valorBruto - valorDesconto;

            return valorLiquido;

        }

    }
}