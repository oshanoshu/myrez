
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System;
using System.Net.Http;
using MyRez.Models;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace MyRez.message
{ 
public class sendmessage
{ 
        public sendmessage(String message1)
        {
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
            const string accountSid = "ACd791963f3a494963617e9e10f0cfafa4";
            const string authToken = "51b8de4d3df405fe3f85863fa122f4a3";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: message1,
                from: new Twilio.Types.PhoneNumber("+12082161461"),
                to: new Twilio.Types.PhoneNumber("+12084062637")
            );

            Console.WriteLine(message.Sid);
        }
    }

}

