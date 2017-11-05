﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoGracias.Communication
{
    static class MessageClass
    {
        
    }

    public enum Messages
    {
        #region Setup
        SEND_PLAYER_NAME_TO_SERVER,
        RECEIVE_CONNECTION_UPDATE_FROM_SERVER,     //--Status, new players joined, ready-up status, etc...
        SEND_READYUP_TO_SERVER,                    //--Tells server that the player is ready 
        ALERT_PLAYER_JOINED,
        ALERT_PLAYER_READY_UPPED,

        #endregion

        #region Turn Logic
        ACCEPT_CARD,
        REJECT_CARD,

        #endregion

        #region Misc
        SEND_NOTHING,                              //--Dummy Message
        SEND_MESSAGE,                              //--Send a message
        #endregion
    }
}