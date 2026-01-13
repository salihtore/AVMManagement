using System;

namespace AVM.Core.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int FloorNumber { get; set; }
        public decimal SquareMeter { get; set; }
        public string Category { get; set; }
        
        // Yeni Eklenen Alanlar
        public string StoreCode { get; set; }
        public string LogoPath { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;   // 🔥 Eklenen özellik

        public DateTime CreatedAt { get; set; } = DateTime.Now;   // opsiyonel ama çok faydalı
        public DateTime? UpdatedAt { get; set; }                  // opsiyonel güncelleme tarihi
    }
}
