using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;
using System.Linq;

namespace PregnancySMS.MessageClasses
{
    public class PregnancyLengthMessage : BaseMessageLogic, IMessageLogic
    {
        public IMessageLogic ProcessUserResponse(string userResponseText, string numberid)
        {
            userResponseText = userResponseText.Trim();
            int responseAsInt = -1;
            if(int.TryParse(userResponseText, out responseAsInt))
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var userNumberEntity = db.Numbers.FirstOrDefault(u => u.Id == numberid);
                    userNumberEntity.Weeks = responseAsInt;
                    db.Entry(userNumberEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return new HasDoctorMessage();
        }

        public string GetMessageText()
        {
            return this.GetMessageTextFromDatabase(1);
        }
    }
}