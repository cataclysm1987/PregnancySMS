using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancySMS.MessageClasses
{
    public class InvalidZipCodeMessage : BaseMessageLogic, IMessageLogic
    {
        public IMessageLogic ProcessUserResponse(string userResponseText, string numberid)
        {
            return new ZipCodeMessage().ProcessUserResponse(userResponseText, numberid);
        }

        public string GetMessageText()
        {
            return this.GetMessageTextFromDatabase(8);
        }
    }
}