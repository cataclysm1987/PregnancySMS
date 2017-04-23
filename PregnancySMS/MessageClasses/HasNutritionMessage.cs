using PregnancySMS.MessageClasses.Helpers;
using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;

namespace PregnancySMS.MessageClasses
{
    public class HasNutritionMessage : BaseMessageLogic, IMessageLogic
    {
        public IMessageLogic ProcessUserResponse(string userResponseText, Number userNumberEntity)
        {
            bool? responseAsBool = new YesNoResponseParser().ConvertToBool(userResponseText);

            if (responseAsBool != null)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    userNumberEntity.HasNutrition = responseAsBool.Value;
                    db.Entry(userNumberEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return new ZipCodeMessage();
        }

        public string GetMessageText()
        {
            return this.GetMessageTextFromDatabase(4);
        }
    }
}