using PregnancySMS.Models;
using System.Linq;

namespace PregnancySMS.MessageClasses
{
    public partial class BaseMessageLogic
    {
        protected string GetMessageTextFromDatabase(int messageId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Messages.Where(x => x.Id == messageId).Single().MessageText;
            }
        }
    }
}