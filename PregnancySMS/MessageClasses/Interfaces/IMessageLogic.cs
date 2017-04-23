using PregnancySMS.Models;

namespace PregnancySMS.MessageClasses.Interfaces
{
    public interface IMessageLogic
    {
        IMessageLogic ProcessUserResponse(string userResponseText, Number userNumberEntity);
        string GetMessageText();
    }
}
