using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoGracias
{
    class Messages
    {
        enum Message
        {
            #region Setup
            SEND_PLAYER_NAME_TO_SERVER,
            RECEIVE_CONNECTION_UPDATE_FROM_SERVER,     //--Status, new players joined, ready-up status, etc...
            SEND_READYUP_TO_SERVER,                    //--Tells server that the player is ready 

            #endregion

            #region Turn Logic

            #endregion

            #region Misc
            SEND_NOTHING,                              //--Dummy Message
            #endregion
        }
    }
}
