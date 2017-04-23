using PregnancySMS.MessageClasses.Helpers;
using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;

namespace PregnancySMS.MessageClasses
{
    public class ZipCodeMessage : BaseMessageLogic, IMessageLogic
    {
        public IMessageLogic ProcessUserResponse(string userResponseText, Number userNumberEntity)
        {
            bool? responseAsBool = new YesNoResponseParser().ConvertToBool(userResponseText);

            if (responseAsBool != null)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    userNumberEntity.HasDoctor = responseAsBool.Value;
                    db.Entry(userNumberEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return new InformationRegisteredMessage();
        }

        public string GetMessageText()
        {
            return this.GetMessageTextFromDatabase(5);
        }
    }
}