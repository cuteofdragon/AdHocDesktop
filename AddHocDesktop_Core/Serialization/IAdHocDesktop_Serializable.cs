using System;

namespace AdHocDesktop.Core
{        
    public interface IAdHocDesktop_Serializable
    {
        byte[] Serialize();
        void Deserialize(byte[] data);
    }

}
