using PregnancySMS.HelperClasses;
using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;
using System;

namespace PregnancySMS.MessageClasses
{
    public class InformationRegisteredMessage : BaseMessageLogic, IMessageLogic
    {
        private readonly string _numberEntryId;

        public InformationRegisteredMessage(string numberEntryId)
        {
            _numberEntryId = numberEntryId;
        }

        public IMessageLogic ProcessUserResponse(string userResponseText, Number userNumberEntity)
        {
            //This message should end the conversation.
            return null;
        }

        public string GetMessageText()
        {
            string messageWithoutAdvice = this.GetMessageTextFromDatabase(6);           
            //Add logic to find local resources, then append to return string.
            return messageWithoutAdvice + Environment.NewLine + new AdviceMessageGenerator().GenerateMessage(_numberEntryId);
        }
    }
}