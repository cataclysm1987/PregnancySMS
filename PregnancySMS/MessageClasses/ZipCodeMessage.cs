using System.Linq;
using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;

namespace PregnancySMS.MessageClasses
{
    public class ZipCodeMessage : BaseMessageLogic, IMessageLogic
    {
        public IMessageLogic ProcessUserResponse(string userResponseText, string numberid)
        {
            string zipCode = userResponseText.Trim();
            bool zipCodeIsValid = true; //replace with code to validate zipcode
            if (zipCodeIsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var userNumberEntity = db.Numbers.FirstOrDefault(u => u.Id == numberid);
                    userNumberEntity.ZipCode = zipCode;
                    db.Entry(userNumberEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return new InformationRegisteredMessage(numberid);
            }
            return new InvalidZipCodeMessage();
        }

        public string GetMessageText()
        {
            return this.GetMessageTextFromDatabase(5);
        }
    }
}