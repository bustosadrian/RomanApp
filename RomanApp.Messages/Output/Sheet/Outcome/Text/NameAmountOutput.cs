using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Output.Sheet.Outcome.Text
{
    [Serializable]
    [Message(KEY)]
    public class NameAmountOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Sheet.Output.Outcome.Name.Amount";

        public NameAmountOutput()
        {

        }

        public NameAmountOutput(string name, decimal value1)
            : this(name, value1, 0)
        {

        }

        public NameAmountOutput(string name, decimal value1, decimal value2)
            : this()
        {
            Name = name;
            Value1 = value1;
            Value2 = value2;
        }

        #region Properties

        public string Name
        {
            get;
            set;
        }

        public decimal Value1
        {
            get;
            set;
        }

        public decimal Value2
        {
            get;
            set;
        }

        #endregion
    }
}
