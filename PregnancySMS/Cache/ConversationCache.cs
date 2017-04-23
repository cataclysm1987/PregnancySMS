using PregnancySMS.MessageClasses.Interfaces;
using System.Collections.Generic;

namespace PregnancySMS.Cache
{
    public class ConversationCache
    {
        private static Dictionary<string, IMessageLogic> _cache = new Dictionary<string, IMessageLogic>();

        public static IMessageLogic GetPreviousMessage(string phoneNumber)
        {
            return lookupMessage(phoneNumber);
        }

        public static void UpdateConversationWithNewMessage(string numberId, IMessageLogic nextMessage)
        {
            IMessageLogic previousMessage = lookupMessage(numberId); //Used this rather than _cache.ContainsKey() to save a lookup
            if (previousMessage != null)
            {
                _cache[numberId] = nextMessage;
            }
            else
            {
                _cache.Add(numberId, nextMessage);
            }
        }

        public static void DeleteConversation(string numberId)
        {
            _cache.Remove(numberId);
        }

        private static IMessageLogic lookupMessage(string numberId)
        {
            IMessageLogic previousMessage;
            _cache.TryGetValue(numberId, out previousMessage);
            return previousMessage;
        }
    }
}