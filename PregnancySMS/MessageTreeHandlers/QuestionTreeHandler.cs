﻿using PregnancySMS.Cache;
using PregnancySMS.MessageClasses;
using PregnancySMS.MessageClasses.Interfaces;
using PregnancySMS.Models;

namespace PregnancySMS.MessageTreeHandlers
{
    public class QuestionTreeHandler
    {
        /// <summary>
        /// Takes the phone number and body of a recieved text message and returns the body of the text
        /// we are going to send next. Returns empty string if we don't need to reply.
        /// </summary>
        /// <param name="numberid"></param>
        /// <param name="userTextContent"></param>
        /// <param name="phoneNumber">The phone number we received a text from.</param>
        /// <param name="messageText">The content of the text message.</param>
        /// <returns></returns>
        public string HandleMessage(string numberid, string userTextContent)
        {
            
            if(userTextContent.ToLower() == "stop")
            {
                //Code to handle unsubscribing
                return "You have been unsubscribed from PrenancySMS.";
            }

            IMessageLogic lastMessageWeSentId = ConversationCache.GetPreviousMessage(numberid);
            IMessageLogic messageToSend;

            if(userTextContent.ToLower() == "baby")
            {
                //create send pregnancy message to cache
                messageToSend = new PregnancyLengthMessage();
            }
            else
            {
                //process message
                messageToSend = lastMessageWeSentId.ProcessUserResponse(userTextContent, numberid);
            }

            string responseMessage = "";
            if(messageToSend != null)
            {
                responseMessage = messageToSend.GetMessageText();
                ConversationCache.UpdateConversationWithNewMessage(numberid, messageToSend);
            }
            else
            {
                ConversationCache.DeleteConversation(numberid);
            }

            return responseMessage;
        }
    }
}