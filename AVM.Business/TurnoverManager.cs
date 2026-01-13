using AVM.Core.Entities;
using AVM.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AVM.Business
{
    public class TurnoverManager
    {
        private UnitOfWork _uow;

        public TurnoverManager()
        {
            _uow = new UnitOfWork();
        }

        public List<Turnover> GetTurnoversByStore(int storeId)
        {
            // Assuming we have a way to filter generic repository or need to add predicate support
            // For now, using simple client-side filter if data is small, or custom query if large.
            // Since repo is generic, we might need filtering. 
            // Let's assume standard GetAll().Where() works for now.
            return _uow.Turnovers.GetAll().Where(t => t.StoreId == storeId).OrderByDescending(t => t.Date).ToList();
        }

        public void AddTurnover(Turnover turnover)
        {
            if (turnover.Amount < 0)
                throw new Exception("Ciro tutarı negatif olamaz.");

            _uow.Turnovers.Add(turnover);
            _uow.Save();
        }
    }
}
