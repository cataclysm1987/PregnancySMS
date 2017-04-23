using PregnancySMS.MessageClasses.Helpers;
using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;
using System.Linq;

namespace PregnancySMS.MessageClasses
{
    public class HasDoctorMessage : BaseMessageLogic, IMessageLogic
    {
        public IMessageLogic ProcessUserResponse(string userResponseText, string numberid)
        {
            bool? responseAsBool = new YesNoResponseParser().ConvertToBool(userResponseText);

            if (responseAsBool != null)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var userNumberEntity = db.Numbers.FirstOrDefault(u => u.Id == numberid);
                    userNumberEntity.HasDoctor = responseAsBool.Value;
                    db.Entry(userNumberEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return new HasInsuranceMessage();
        }

        public string GetMessageText()
        {
            return this.GetMessageTextFromDatabase(2);
        }
    }
}