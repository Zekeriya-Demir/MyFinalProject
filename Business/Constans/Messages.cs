using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    // constans  - sabitler
    // static classlar new'lenmeden ulaşılır
    // public değişkenler pascal case yazılır.
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";

        public static string ProductNameExsist = "Ürün ismi aynı olamaz";
        public static string CategoryLimitExceded= "Kategori limit sınırını aştığı için yeni ürün eklenemez.";
    }
}
