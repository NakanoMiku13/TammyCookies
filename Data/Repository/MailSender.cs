using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using TiendaEnLinea2.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace TiendaEnLinea2.Data.Repository
{
    public class MailSender
    {
        protected string Smtpserver;
        protected string Sender;
        protected string Admin;
        protected string Admin2 = "danulricht@hotmail.com";
        protected string pwd;
        protected int Port;
        public MailSender()
        {
            Smtpserver= Startup.StaticConfig["Secrets:Auth:Local:Sender:Server"];
            Sender= Startup.StaticConfig["Secrets:Auth:Local:Sender:Sender"];
            Admin= Startup.StaticConfig["Secrets:Auth:Local:Sender:Admin"];
            pwd= Startup.StaticConfig["Secrets:Auth:Local:Sender:Pwd"];
            Port=Convert.ToInt32(Startup.StaticConfig["Secrets:Auth:Local:Sender:Port"]);
        }
        protected private void SMTPDATA(MimeMessage message)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(Smtpserver, Port, false);
                client.Authenticate(Sender, pwd);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        protected MimeMessage Message(MailboxAddress From, MailboxAddress To, string text, string subject,string backurl)
        {
            var x = new MimeMessage();
            x.From.Add(From);
            x.To.Add(To);
            x.Subject = subject;
            if (string.IsNullOrEmpty(backurl))
            {
                x.Body = new TextPart()
                {
                    Text = text
                };
            }
            else
            {
                string message = text + "\n" + backurl;
                x.Body = new TextPart()
                {
                    Text = message
                };
            }
            return x;
        }
        public void SendMailToAdmin(Contacto cont)
        {
            var From = new MailboxAddress("Tienda En Linea Soporte", Sender);
            var To = new MailboxAddress("Admin", Admin);
            var To2 = new MailboxAddress("Admin", Admin2);
            string Subject = "Mensaje nuevo de: " + cont.userid;
            string text = "Se ha recibido un mensaje del usuario " + cont.userid + " el " + cont.Published.ToString() + ".\n" + cont.Mensaje;
            SMTPDATA(Message(From,To,text,Subject,null));
            SMTPDATA(Message(From, To2, text, Subject, null));
        }
        public void SendMailToUser(Respuesta resp,ApplicationDbContext context)
        {
            var user = context.Users.FirstOrDefault(P=>P.Id==resp.userid);
            var From = new MailboxAddress("Tienda En Linea Soporte", Sender);
            var To = new MailboxAddress(user.UserName, user.Email);
            string Subject = "Gracias por ponerte en contacto con nosotros.";
            string text = "Recibimos un mensaje de usted y nos gustaría darle nuestra respuesta: \n" + resp.Mensaje + "\n\n\nEnviado: " + resp.Fecha;
            SMTPDATA(Message(From, To, text, Subject, null));
        }
        public void SendConfirmationMail(IdentityUser user,string backurl)
        {
            var From = new MailboxAddress("Tienda En Linea Soporte", Sender);
            var To = new MailboxAddress(user.UserName, user.Email);
            string Subject = "Gracias por registrarse.";
            string text = "Para activar su cuenta, de click en el siguiente enlace: \n";
            SMTPDATA(Message(From, To, text, Subject, backurl));
        }
        public void SendForgotMail(IdentityUser user, string backurl) 
        {
            var From = new MailboxAddress("Tienda En Linea Soporte", Sender);
            var To = new MailboxAddress(user.UserName, user.Email);
            string Subject = "Gracias por registrarse.";
            string text = "Restaura tu contraseña aquí: \n";
            SMTPDATA(Message(From, To, text, Subject, backurl));
        }
        public void SendMailToUserTicket(List<OrderDetail> items, Order order,ApplicationDbContext context)
        {
            var From = new MailboxAddress("Tienda En Linea Soporte", Sender);
            var To = new MailboxAddress(order.Nombre, order.Mail);
            string Subject = "Gracias por su compra " +order.Nombre;
            string lista="";
            foreach(var item in items)
            {
                var Prod = context.Producto.FirstOrDefault(p=>p.id==Convert.ToInt32(item.Prodid));
                lista += Prod.Nombre + " " + Prod.Descripcion + " $" + Prod.Precio+"\n";
            }
            string text = "Los productos que compraste fueron los siguientes: \n"+lista+"\nCon referencia de pago: "+order.RefPago;
            SMTPDATA(Message(From, To, text, Subject, null));
        }
        public void SendMailToAdminNewSell(Order order, List<OrderDetail> items, ApplicationDbContext context)
        {
            var From = new MailboxAddress("Tienda En Linea Soporte", Sender);
            var To = new MailboxAddress("Admin",Admin);
            string Subject = "Se ha realizado una compra";
            string lista = "";
            foreach (var item in items)
            {
                var Prod = context.Producto.FirstOrDefault(p => p.id == Convert.ToInt32(item.Prodid));
                lista += Prod.Nombre + " " + Prod.Descripcion + " $" + Prod.Precio + "\n";
            }
            string text = "El usuario "+order.Nombre+" "+order.userid+" compro los siguinetes productos: \n" + lista + "\nCon referencia de pago: " + order.RefPago;
            SMTPDATA(Message(From, To, text, Subject,null ));
        }
        public void SendMailUserSended(Order order)
        {
            var From = new MailboxAddress("Tienda En Linea Soporte", Sender);
            var To = new MailboxAddress(order.Nombre, order.Mail);
            string Subject = "Se ha enviado tu producto";
            string text = "Se ha realizado el envío de tu producto, este estará llegando a tu domicilio mediante ESTAFETA, el código de seguimiento se enviará en las proximas horas";
            SMTPDATA(Message(From, To, text, Subject, null));
        }
        public void SendMailUserCancel(Order order)
        {
            var From = new MailboxAddress("Tienda En Linea Soporte", Sender);
            var To = new MailboxAddress(order.Nombre, order.Mail);
            string Subject = "Se ha cancelado tu pedido";
            string text = "Se ha realizado la cancelación de tu pedido, en unas horas nos pondremos en contacto contigo para hacerte la devolución parcial o total, dependiendo la situación.";
            SMTPDATA(Message(From, To, text, Subject, null));
        }
        public void SendMailToAdminCancelOrder(Order order)
        {
            var From = new MailboxAddress("Tienda En Linea Soporte", Sender);
            var To = new MailboxAddress("Admin", Admin);
            var To2 = new MailboxAddress("Admin", Admin2);
            string Subject = "Cancelación de compra";
            string text = "Se ha realizado una cancelación a la orden "+order.id;
            SMTPDATA(Message(From, To, text, Subject, null));
            SMTPDATA(Message(From, To2, text, Subject, null));
        }
    }
}
