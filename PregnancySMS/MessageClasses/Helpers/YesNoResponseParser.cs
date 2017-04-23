namespace PregnancySMS.MessageClasses.Helpers
{
    public class YesNoResponseParser
    {
        public bool? ConvertToBool(string yesOrNoResponse)
        {
            yesOrNoResponse = yesOrNoResponse.Trim();
            return yesOrNoResponse.Substring(0, 1) == "y" ? true : 
                yesOrNoResponse.Substring(0, 1) == "n" ? false : (bool?)null;
        }
    }
}