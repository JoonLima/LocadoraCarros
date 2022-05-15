namespace LocadoraCarros.Services
{
    class ServicoTaxaBrasil : IServicoDeTaxa
    {
        public double Taxa(double valor)
        {
            if (valor <= 100)
            {
                return valor * 0.2;
            }
            else
            {
                return valor * 0.15;
            }
        }
    }
}
