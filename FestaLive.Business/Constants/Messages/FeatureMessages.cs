using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Constants.Messages
{
    internal class FeatureMessages
    {
        public static string FeatureAddedSuccessfully => "Öne Çıkan başarıyla eklendi.";
        public static string FeatureUpdatedSuccessfully => "Öne Çıkan başarıyla güncellendi.";
        public static string FeatureDeletedSuccessfully => "Öne Çıkan başarıyla silindi.";

        public static string FeatureNotFound => "Öne Çıkan bulunamadı.";
        public static string InvalidFeatureId => "Geçersiz Öne Çıkan ID'si.";

        public static string InvalidStartDate => "Geçersiz başlangıç tarihi.";
        public static string InvalidEndDate => "Geçersiz bitiş tarihi.";

        public static string FeatureListed => "Öne Çıkanlar başarıyla listelendi.";
        public static string FeaturesNotFound => "Öne Çıkanlar bulunamadı.";

        public static string FeatureValidationFailed => "Öne Çıkan doğrulaması başarısız oldu.";
    }

}
