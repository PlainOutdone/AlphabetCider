using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetCider.Domain.Controller
{
    public interface IController
    {
        string EncryptMessage(string secret, string message);
    }
}
