using Microsoft.EntityFrameworkCore;
using UniversalMessengerAPI.Model;
using UniversalMessengerLibrary2.Services;

namespace UniversalMessengerAPI.Services
{
    public class TwilioService : TwilioBase
    {
        DatabaseContext context = new DatabaseContext();

        public TwilioService(string senderPhoneNumber) : base(senderPhoneNumber){}

        public TwilioService(string accountSid, string authToken, string senderPhoneNumber) : base(accountSid, authToken, senderPhoneNumber) {}

        public List<string> GetRecipients()
        {
            FillRecipients();
            return Recipients;
        }

        public override void AddRecipient(string recipient)
        {
            Recipient newRecipient = new Recipient();
            newRecipient.Value = recipient;
            newRecipient.Service = "Twilio";
            context.Recipients.Add(newRecipient);
            context.SaveChanges();
        }

        public override void FillRecipients()
        {
            List<Recipient> recipients = context.Recipients.Where(recipient => recipient.Service == "Twilio").ToList();
            foreach (Recipient recipient in recipients) Recipients.Add(recipient.Value);
        }
    }
}
