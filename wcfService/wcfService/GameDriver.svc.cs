using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Common;

namespace wcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant
        , InstanceContextMode = InstanceContextMode.Single)]
    public class GameDriver : IGameDriver
    {
        #region Member Variables
        private int mNumberOfPlayers = 0;
        private List<Player> mPlayers = new List<Player>();
        // The current callback object
        private IGameDriverCallback _currentCallback;

        // Storage containers
        static Dictionary<string, IGameDriverCallback> _callbacks = new Dictionary<string, IGameDriverCallback>();
        private const string ERROR_USER_ALREADY_EXISTS = "User already registered.";
        private const string FORMAT_USER_REGISTERED = "{0} has registered.";
        #endregion

        public void RegisterUser(string aUsername)
        {
            //mNumberOfPlayers++;
            //mPlayers.Add(new Player() { mPlayerNumber = mNumberOfPlayers, mName = aUsername, chips = 11 });
            _currentCallback = OperationContext.Current.GetCallbackChannel<IGameDriverCallback>();

            // Store callback
            if (!_callbacks.ContainsKey(aUsername))
            {
                _callbacks.Add(aUsername, _currentCallback);

                // Notify user of registration
                _currentCallback.OnUserRegistered(aUsername);

                // Notify clients of new user
                foreach (string userKey in _callbacks.Keys)
                {
                    _currentCallback = _callbacks[userKey];
                    _currentCallback.OnPublishChat("Mittens", string.Format(FORMAT_USER_REGISTERED, aUsername));
                }
            }
            else
            {
                // User already registered, throw exception
                throw new Exception(ERROR_USER_ALREADY_EXISTS);
            }
        }

        #region Proof Of Concept
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string GetBent()
        {
            return "Get Bent!";
        }
        #endregion

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
