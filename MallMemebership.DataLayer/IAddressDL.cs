using MallMembership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallMemebership.DataLayer
{
   public interface IAddressDL
    {
        bool AddAddressDA(AddressInfo addressInfo);
        AddressInfo GetAddressByIdDA(int id);
        bool UpdateAddressDA(AddressInfo addressInfo);
   
    }
}
