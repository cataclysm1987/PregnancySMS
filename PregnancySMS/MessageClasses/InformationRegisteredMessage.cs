using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;

namespace PregnancySMS.MessageClasses
{
    public class InformationRegisteredMessage : BaseMessageLogic, IMessageLogic
    {
        public IMessageLogic ProcessUserResponse(string userResponseText, Number userNumberEntity)
        {
            //This message should end the conversation.
            return null;
        }

        public string GetMessageText()
        {
            string messageWithoutAdvice = this.GetMessageTextFromDatabase(6);
            string advice = "";
            //Add logic to add bits of advice here.
            return messageWithoutAdvice + advice;
        }
    }
}