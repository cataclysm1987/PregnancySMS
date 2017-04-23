using PregnancySMS.Models;

namespace PregnancySMS.MessageClasses.Interfaces
{
    public interface IMessageLogic
    {
        IMessageLogic ProcessUserResponse(string userResponseText, string numberid);
        string GetMessageText();
    }
}
