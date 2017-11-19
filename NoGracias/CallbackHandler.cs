using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace NoGracias
{
    public class CallbackHandler : IGameDriverCallback
    {
        public void OnUserRegistered(string aUsername)
        {
            throw new NotImplementedException();
        }

        public void OnPublishChat(string aUsername, string aChatMessage)
        {
            throw new NotImplementedException();
        }
    }
}
