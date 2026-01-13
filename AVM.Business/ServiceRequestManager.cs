using AVM.Core.Entities;
using AVM.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AVM.Business
{
    public class ServiceRequestManager
    {
        private UnitOfWork _uow;

        public ServiceRequestManager()
        {
            _uow = new UnitOfWork();
        }

        public List<ServiceRequest> GetRequestsByStore(int storeId)
        {
            return _uow.ServiceRequests.GetAll()
                       .Where(r => r.StoreId == storeId)
                       .OrderByDescending(r => r.CreatedAt)
                       .ToList();
        }

        public object GetAllRequestsDetailed()
        {
            var requests = _uow.ServiceRequests.GetAll();
            var stores = _uow.Stores.GetAll();

            var query = from r in requests
                        join s in stores on r.StoreId equals s.StoreId
                        select new
                        {
                            r.RequestId,
                            StoreName = s.StoreName,
                            RequestType = r.RequestType,
                            r.Description,
                            r.Status,
                            r.CreatedAt,
                            r.ResolvedAt
                        };

            return query.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public void AddRequest(ServiceRequest request)
        {
            if (string.IsNullOrEmpty(request.Description))
                throw new Exception("Açıklama boş olamaz.");
            
            _uow.ServiceRequests.Add(request);
            _uow.Save();
        }

        public void UpdateStatus(int requestId, string status)
        {
            var req = _uow.ServiceRequests.Get(requestId);
            if(req != null)
            {
                req.Status = status;
                if(status == "Resolved" || status == "Completed")
                    req.ResolvedAt = DateTime.Now;
                
                _uow.ServiceRequests.Update(req);
                _uow.Save();
            }
        }
    }
}
