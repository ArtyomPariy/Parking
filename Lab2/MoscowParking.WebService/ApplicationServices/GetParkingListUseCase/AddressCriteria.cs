using MoscowParking.DomainObjects;
using MoscowParking.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoscowParking.ApplicationServices.GetParkingListUseCase
{
    public class AddressCriteria : ICriteria<Parking>
    {
        public string Address { get; }

        public AddressCriteria(string address)
            => Address  = address;

        public Expression<Func<Parking, bool>> Filter
            => (p => p.Address == Address);
    }
}
