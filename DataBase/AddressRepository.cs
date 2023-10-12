using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class AddressRepository: IAddressRepository
    {
        protected readonly MyDbContext _myDbContext;
        public AddressRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
    }
}
