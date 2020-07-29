using MallMembership.Entities;
using MallMemebership.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallMembership.BusinessLayer
{
   public class AddressBusiness : IAddressBusiness
    {
        private readonly IAddressDL _addressDL;

      public  AddressBusiness(IAddressDL addressDL)
        {
            _addressDL = addressDL;
        }
        public bool AddAddressBL(AddressInfo addressInfo)
        {
            try
            {
                bool result = _addressDL.AddAddressDA(addressInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AddressInfo GetAddressByIdBL(int id)
        {
            try
            {
                AddressInfo addressInfo = _addressDL.GetAddressByIdDA(id);
                return addressInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateAddressBL(AddressInfo addressInfo)
        {
            try
            {
                bool result = _addressDL.UpdateAddressDA(addressInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
