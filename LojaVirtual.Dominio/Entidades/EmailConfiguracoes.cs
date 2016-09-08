namespace LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public string De = "lojavirtual@lojavirtual.com.br";
        public bool EscreverArquivo = false;
        public string Para = "pedido@lojavirtual.com.br";
        public string PastaArquivo = @"C:\envioemail";
        public int ServidorPorta = 587;
        public string ServidorSmtp = "smtp.lojavirtual.com.br"; 
        public bool UsarSsl = false;
        public string Usuario = "admin";
    }
}