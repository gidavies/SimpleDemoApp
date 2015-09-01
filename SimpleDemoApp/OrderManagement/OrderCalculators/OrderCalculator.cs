using System;
using Models;

namespace Contracts
{

    public class OrderCalculator
    {

        public uint CalculateOrderCosts(Customer customer, IOrderManagement contract)
        {
            var taxExemption = contract.ReOrder(
                customer.Property.IsCreditChecked,
                customer.Property.Location,
                customer.AnnualBasicOrder,
                customer.Property.MonthlyQuantity,
                customer.AnnualOrderDiscountAllowance);

            return taxExemption;
        }

    }

}
