using Core.Interface.Repository;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class AddressService : IAddressService
    {
        protected readonly IAddressService addressRepository;
        public AddressService(IAddressService addressRepository)
        {
            this.addressRepository = addressRepository;
        }
    }
}
