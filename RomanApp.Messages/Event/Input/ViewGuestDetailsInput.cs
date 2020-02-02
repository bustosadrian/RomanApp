using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Event.Input
{
    [Serializable]
    [Message(KEY)]
    public class ViewGuestDetailsInput : ViewItemDetailsInput
    {
        private const string KEY = "RomanApp.Event.View.Guest.Details.Input";

    }
}
