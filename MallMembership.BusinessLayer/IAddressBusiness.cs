using MallMembership.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallMembership.BusinessLayer
{
   public interface IAddressBusiness
    {
        bool AddAddressBL(AddressInfo addressInfo);
        AddressInfo GetAddressByIdBL(int id);
        bool UpdateAddressBL(AddressInfo addressInfo);
    }
}
