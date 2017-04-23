using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;

namespace PregnancySMS.MessageClasses
{
    public class ZipCodeMessage : BaseMessageLogic, IMessageLogic
    {
        public IMessageLogic ProcessUserResponse(string userResponseText, Number userNumberEntity)
        {
            string zipCode = userResponseText.Trim();
            bool zipCodeIsValid = true; //replace with code to validate zipcode
            if (zipCodeIsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    userNumberEntity.ZipCode = zipCode;
                    db.Entry(userNumberEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return new InformationRegisteredMessage(userNumberEntity.Id);
            }
            return new InvalidZipCodeMessage();
        }

        public string GetMessageText()
        {
            return this.GetMessageTextFromDatabase(5);
        }
    }
}