using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoGracias.Communication
{
    static class MessageClass
    {
        
    }
    /**
    *	Public Enumeration 
    *	Details: Describes the type of message being sent from players and servers
    */
    public enum Messages
    {
        #region Setup
        SEND_PLAYER_NAME_TO_SERVER,
        RECEIVE_CONNECTION_UPDATE_FROM_SERVER,     //--Status, new players joined, ready-up status, etc...
        SEND_READYUP_TO_SERVER,                    //--Tells server that the player is ready 
        ALERT_PLAYER_JOINED,
        ALERT_PLAYER_READY_UPPED,
        #endregion

        #region Game Setup
        RECEIVE_PLAYER_POSITION,
        #endregion

        #region Turn Logic
        RECEIVE_TURN_CARD,
        RECEIVE_TURN_PLAYER,
        RECEIVE_TURN_OPTIONS,
        ACCEPT_CARD,
        REJECT_CARD,
        #endregion

        #region Game End
        RECEIVE_PLAYER_SCORE,
        #endregion

        #region Misc
        SEND_NOTHING,                              //--Dummy Message
        SEND_MESSAGE,                              //--Send a message
        #endregion
    }
}
