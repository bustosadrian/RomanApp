﻿using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class AddGuestInput : AddItemInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Add.Guest";
        
    }
}
