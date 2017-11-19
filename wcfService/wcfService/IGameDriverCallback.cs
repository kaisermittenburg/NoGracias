using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Common
{
    public interface IGameDriverCallback
    {
        //Have the client handle a new player, such as add a place at the table
        [OperationContract(IsOneWay = true)]
        void OnUserRegistered(string userName);

        //Stub for now
        [OperationContract(IsOneWay = true)]
        void OnPublishChat(string userName, string chatMessage);
    }
}