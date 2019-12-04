// Install the C# / .NET helper library from twilio.com/docs/csharp/install

using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using MyRez.message;
using System.Collections.ObjectModel;
using MyRez.Models;
using MyRez.Database;
using System.Threading.Tasks;
using System.Linq;

namespace MyRez.message
{
    public class SendEmergencyNotifications
    {
        public SendEmergencyNotifications(string Category, string Message, ObservableCollection<MockUsers> mockUsers)
        {
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
            const string accountSid = "AC4bdaa8925e71bd2db93caf781a5f48ce";
            const string authToken = "52bede6bd94297a60b015d7064734546";
            ObservableCollection<MockUsers> mockUser = mockUsers;
            List<String> phoneNumbers = (from mock in mockUser select "+1"+mock.phone).ToList();

            TwilioClient.Init(accountSid, authToken);

            foreach (var number in phoneNumbers)
            {
                var message = MessageResource.Create(
                    body: Category + "\n" + Message,
                    from: new Twilio.Types.PhoneNumber("+12015914082"),
                    to: new Twilio.Types.PhoneNumber(number)
                );

                Console.WriteLine($"Message to {number} has been {message.Status}.");
            }
        }
       
        
    }
}