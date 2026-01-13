using System;
using System.Collections.Generic;
using System.Linq;
using AVM.Core.Entities;
using AVM.DataAccess;

namespace AVM.Business
{
    public class RentManager
    {
        private readonly UnitOfWork _uow;

        public RentManager()
        {
            _uow = new UnitOfWork();
        }

        public void GenerateCurrentMonthRents()
        {
            var activeContracts = _uow.Contracts.GetAll()
                .Where(c => c.EndDate >= DateTime.Today && c.StartDate <= DateTime.Today)
                .ToList();

            var currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            foreach (var contract in activeContracts)
            {
                // Check if rent already exists for this month and contract
                var existingRent = _uow.Rents.GetAll()
                    .FirstOrDefault(r => r.ContractId == contract.ContractId && 
                                         r.RentMonth.Year == currentMonth.Year && 
                                         r.RentMonth.Month == currentMonth.Month);

                if (existingRent == null)
                {
                    var newRent = new Rent
                    {
                        ContractId = contract.ContractId,
                        RentMonth = currentMonth,
                        Amount = contract.MonthlyRent,
                        IsPaid = false,
                        LateFee = 0,
                        PaidAt = null
                    };

                    _uow.Rents.Add(newRent);
                }
            }
            _uow.Save();
        }

        public void MakePayment(int rentId, decimal amount, string paymentType, string description)
        {
            var rent = _uow.Rents.Get(rentId);
            if (rent == null) throw new Exception("Kira kaydı bulunamadı.");

            var contract = _uow.Contracts.Get(rent.ContractId);
            if (contract == null) throw new Exception("Sözleşme bulunamadı.");

            var payment = new Payment
            {
                RentId = rentId,
                TenantId = contract.TenantId,
                Amount = amount,
                PaymentType = paymentType,
                Description = description,
                PaidAt = DateTime.Now
            };

            _uow.Payments.Add(payment);

            _uow.Save(); // Save payment first to ensure it's in DB for calculation if strictly needed, but here we can calc in memory or refetch. 
                         // Refactoring note: We switched to IQueryable. Getting all payments for rent again is a DB hit.
                         // But for accurate total calculation including the one we just added (if DB generated IDs matter or triggers),
                         // usually adding to memory collection is enough if we haven't saved.
                         // However, since we called Save() above for payment, we can fetch afresh.
            
            var allPayments = _uow.Payments.GetAll().Where(p => p.RentId == rentId).ToList();
            var totalPaid = allPayments.Sum(p => p.Amount);

            if (totalPaid >= rent.Amount)
            {
                rent.IsPaid = true;
                rent.PaidAt = DateTime.Now;
            }
            else
            {
                rent.IsPaid = false; 
                rent.PaidAt = null; 
            }
            
            _uow.Rents.Update(rent);
            _uow.Save();
        }

        public object GetRentsByStore(int storeId)
        {
            var rents = _uow.Rents.GetAll();
            var contracts = _uow.Contracts.GetAll();
            var tenants = _uow.Tenants.GetAll();
            var payments = _uow.Payments.GetAll();

            // Filter by StoreId
            var query = from r in rents
                        join c in contracts on r.ContractId equals c.ContractId
                        join t in tenants on c.TenantId equals t.TenantId
                        where t.StoreId == storeId
                        select new
                        {
                            r.RentId,
                            Period = r.RentMonth, 
                            Amount = r.Amount,
                            PaidAmount = payments.Where(p => p.RentId == r.RentId).Sum(p => (decimal?)p.Amount) ?? 0,
                            PaidDate = r.PaidAt,
                            r.LateFee
                        };
            
            var result = query.ToList().Select(x => new 
            {
                x.RentId,
                Period = x.Period.ToString("MMMM yyyy"),
                x.Amount,
                x.PaidAmount,
                RemainingAmount = (x.Amount - x.PaidAmount) < 0 ? 0 : (x.Amount - x.PaidAmount),
                PaidStatus = (x.PaidAmount >= x.Amount) ? "Tamamlandı" : (x.PaidAmount > 0) ? "Kısmi Ödendi" : "Ödenmedi",
                PaidDate = x.PaidDate.HasValue ? x.PaidDate.Value.ToShortDateString() : "-"
            }).OrderByDescending(x => x.Period).ToList();

            return result;
        }

        public object GetAllRentsDetailed()
        {
            var rents = _uow.Rents.GetAll();
            var contracts = _uow.Contracts.GetAll();
            var tenants = _uow.Tenants.GetAll();
            var stores = _uow.Stores.GetAll();
            var payments = _uow.Payments.GetAll();

            var query = from r in rents
                        join c in contracts on r.ContractId equals c.ContractId
                        join t in tenants on c.TenantId equals t.TenantId
                        join s in stores on t.StoreId equals s.StoreId
                        select new
                        {
                            r.RentId,
                            Period = r.RentMonth,
                            StoreName = s.StoreName,
                            TenantName = t.CompanyName,
                            Amount = r.Amount,
                            PaidAmount = payments.Where(p => p.RentId == r.RentId).Sum(p => (decimal?)p.Amount) ?? 0,
                            PaidDate = r.PaidAt
                        };
            
            var result = query.ToList().Select(x => new 
            {
                x.RentId,
                Period = x.Period.ToString("MMMM yyyy"),
                x.StoreName,
                x.TenantName,
                x.Amount,
                x.PaidAmount,
                RemainingAmount = (x.Amount - x.PaidAmount) < 0 ? 0 : (x.Amount - x.PaidAmount),
                PaidStatus = (x.PaidAmount >= x.Amount) ? "Tamamlandı" : (x.PaidAmount > 0) ? "Kısmi Ödendi" : "Ödenmedi",
                PaidDate = x.PaidDate.HasValue ? x.PaidDate.Value.ToShortDateString() : "-",
            }).OrderByDescending(x => x.Period).ToList();

            return result;
        }
    }
}
