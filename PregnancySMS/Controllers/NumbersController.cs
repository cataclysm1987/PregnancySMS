using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNet.Identity;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.Types;

namespace PregnancySMS.Controllers
{
    public class NumbersController : TwilioController
    {

        [HttpPost]
        public ActionResult Index(string Body, string FromZip, string From)
        {
            Body += " bacon";
            From += " hello";
            var user = User.Identity.GetUserId();
            var myname = "Eric";
            return View();
        }

        // GET: Numbers
        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Test()
        {
            const string accountSid = "ACaa12252f58fe8c2e4f34fab8a45327b4";
            const string authToken = "af0330dcde83e1de6891142b690db658";

            // Initialize the Twilio client
            TwilioClient.Init(accountSid, authToken);

            // make an associative array of people we know, indexed by phone number
            var people = new Dictionary<string, string>()
            {
                {"+14407810814", "Curious George"}
            };

            // Iterate over all our friends
            foreach (var person in people)
            {
                // Send a new outgoing SMS by POSTing to the Messages resource
                MessageResource.Create(
                    from: new PhoneNumber("216-450-6603"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber(person.Key), // To number, if using Sandbox see note above
                    // Message content
                    body: $"Hey {person.Value} Monkey Party at 6PM. Bring Bananas!");

                Console.WriteLine($"Sent message to {person.Value}");

            }
            return View();
        }

        // POST: Sms/Message
        [HttpPost]
        public ActionResult Message(string From, string Body)
        {
            ViewBag.Message = Body;
            return View();
        }

        //[HttpPost]
        //public ActionResult Index()
        //{
        //    var messagingResponse = new MessagingResponse();
        //    messagingResponse.Message("The Robots are coming! Head for the hills!");

        //    return TwiML(messagingResponse);
        //}

    }
}