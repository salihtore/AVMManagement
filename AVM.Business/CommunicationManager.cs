using System;
using System.Collections.Generic;
using System.Linq;
using AVM.Core.Entities;
using AVM.DataAccess;

namespace AVM.Business
{
    public class CommunicationManager
    {
        private UnitOfWork _uow;

        public CommunicationManager()
        {
            _uow = new UnitOfWork();
        }

        public void SendAnnouncement(string title, string content)
        {
            var announcement = new Announcement
            {
                Title = title,
                Content = content,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            _uow.Announcements.Add(announcement);
            _uow.Save();
        }

        public List<Announcement> GetActiveAnnouncements()
        {
            return _uow.Announcements.GetAll()
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.CreatedDate)
                .ToList();
        }

        public void SendMessage(int senderId, int receiverId, string content)
        {
            var msg = new Message
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = content,
                SentDate = DateTime.Now,
                IsRead = false
            };
            _uow.Messages.Add(msg);
            _uow.Save();
        }

        public List<Message> GetMessagesForUser(int userId)
        {
            // Assuming GetAll() brings everything, inefficient but okay for MVP.
            // Ideally Repository should have Find(predicate) or GetMessagesByUser(userId).
            // Using GetAll + LINQ
            return _uow.Messages.GetAll()
                .Where(m => m.ReceiverId == userId)
                .OrderByDescending(m => m.SentDate)
                .ToList();
        }

        public void DeleteAnnouncement(int id)
        {
            _uow.Announcements.Delete(id);
            _uow.Save();
        }
    }
}
