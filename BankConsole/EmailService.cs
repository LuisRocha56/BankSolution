using MailKit.Net.Smtp;
using MimeKit; 

namespace BankConsole;

public static class EmailServeice
{
    public static void SendEmail()
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress ("Luis Rocha", "luisrocha.v.340@gmail.com"));
        message.To.Add(new MailboxAddress ("admin", "vinceluis340@gmail.com"));
        message.Subject = "BankConsole: Usuarios nuevos";

        message.Body = new TextPart("plain"){
            Text = GetEmailText()
        };

        using (var client = new SmtpClient ()){
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("luisrocha.v.340@gmail.com", "hzyojcypepnxpnmk");
            client.Send(message);
            client.Disconnect(true);
        }
    }

    private static string GetEmailText ()
    {
        List<User> newUser = Storage.GetNewUsers();

        if (newUser.Count == 0)
        {
            return "No hay usuarios nuevos.";
        }

        string emailText = "Usuarios agregados hoy:\n";

        foreach (User user in newUser)
        {
            emailText += "\t+ " + user.ShowData() + "\n";
        }

        return emailText;
    }
}