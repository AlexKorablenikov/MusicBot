﻿using System;
using System.Collections.Generic;
using NameThatTuneBot.Messengers;
using NameThatTuneBot;
using NameThatTuneBot.MessageHandler;
using NameThatTuneBot.MessageHandler.Interfaces;

namespace NameThatTuneBot.MessageHandler
{
    public class MessageRegister:IMessageRegister
    { 
        private readonly Dictionary<User, UserStates> userStates;

        public MessageRegister()
        {
            this.userStates = new Dictionary<User, UserStates>();
        }

        public UserStates RegisterMessage(Message message)
        {
            var id = message.User;
            lock (userStates)
            {
                if (userStates.ContainsKey(id))
                {
                    return userStates[id];
                }
                else
                {
                    userStates.Add(id, UserStates.FirstLevel);
                    return UserStates.FirstLevel;
                }
            }
        }

        public void SetState(Message message, UserStates states)
        {
            var id = message.User;
            lock (userStates)
            {
                if (userStates.ContainsKey(id))
                {
                    userStates[id] = states;

                }
                else
                {
                    userStates.Add(id, UserStates.FirstLevel);
                }
            }
        }

        public UserStates GetState(Message message)
        {
            var id = message.User;
            lock (userStates)
            {
                if (userStates.ContainsKey(id))
                {
                    return userStates[id];
                }
                else
                {
                    throw new Exception("Message doesn't register");
                }
            }
        }
    }
}