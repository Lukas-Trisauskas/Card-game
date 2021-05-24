using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    [Serializable]
    class KeyException : Exception
    {
        public KeyException()
        {

        }
        public KeyException(string message) : base(message)
        {

        }
    }
}
