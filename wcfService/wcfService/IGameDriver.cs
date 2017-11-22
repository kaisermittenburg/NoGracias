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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IGameDriverCallback))]
    public interface IGameDriver
    {
        [OperationContract(IsOneWay = true)]
        void RegisterUser(string aUsername);

        

        #region Proof Of Concept
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string GetBent();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        #endregion

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
