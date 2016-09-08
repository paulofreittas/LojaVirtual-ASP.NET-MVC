using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Entidades
{
    public class EmailProcessarPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailProcessarPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = _emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.ServidorSmtp);

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder();
                body.AppendLine("Novo Pedido");
                body.AppendLine("-----------");
                body.AppendLine("Itens: ");

                foreach (var item in carrinho.ItensCarrinho)
                {
                    var subtotal = item.Produto.Preco*item.Quantidade;
                    body.Append($"{item.Quantidade} x {item.Produto.Nome} (Subtotal: {subtotal:c}");
                }

                body.AppendLine($"Valor total do pedido: {carrinho.ObterValorTotal():c}");
                body.AppendLine("-----------------");
                body.AppendLine("Enviar para: ");
                body.AppendLine(pedido.NomeCliente);
                body.AppendLine(pedido.Email);
                body.AppendLine(pedido.Endereco ?? "");
                body.AppendLine(pedido.Cidade ?? "");
                body.AppendLine(pedido.Complemento ?? "");
                body.AppendLine("-----------------");
                body.AppendFormat("Para Presente? {0}", pedido.EmbrulharPresente ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(_emailConfiguracoes.De, _emailConfiguracoes.Para, "Novo Pedido", body.ToString());

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
