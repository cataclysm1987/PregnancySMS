using PregnancySMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancySMS.HelperClasses
{
    public class AdviceMessageGenerator
    {
        public string GenerateMessage(string numberId)
        {
            string advice = "";
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                int? weeks = db.Numbers.Where(x => x.Id == numberId).Single().Weeks;
                List<string> adviceList;
                if (weeks.HasValue)
                {
                    int trimester = (weeks.Value % 12) + 1;

                    if (trimester >= 4)
                    {
                        trimester = 4;
                        advice += Environment.NewLine + "Your baby has already been born! Here are early child care tips.";
                    }
                    else
                    {
                        string trimesterText = "";
                        switch (trimester)
                        {
                            case 1:
                                trimesterText = "first";
                                break;
                            case 2:
                                trimesterText = "second";
                                break;
                            case 3:
                                trimesterText = "third";
                                break;
                        }
                        advice += Environment.NewLine + $@"You are in the {trimesterText} trimester! Here are some tips for this period of the pregnancy.";
                    }
                    adviceList = db.Advice.Where(x => x.Trimester == trimester).Select(x => x.AdviceText).ToList<string>();
                }
                else
                {
                    adviceList = db.Advice.Select(x => x.AdviceText).ToList<string>();
                }
                Random random = new Random();
                advice += Environment.NewLine + Environment.NewLine + adviceList[random.Next(1, adviceList.Count / 2)];
                advice += Environment.NewLine + Environment.NewLine + adviceList[random.Next(adviceList.Count / 2, adviceList.Count - 1)];
            }
            return advice;
        }
    }
}