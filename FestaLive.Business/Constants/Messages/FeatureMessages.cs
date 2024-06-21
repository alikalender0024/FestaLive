using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.Constants.Messages
{
    public class FeatureMessages
    {
        public static string FeatureAddedSuccessfully => "Featured item added successfully.";
        public static string FeatureUpdatedSuccessfully => "Featured item updated successfully.";
        public static string FeatureDeletedSuccessfully => "Featured item deleted successfully.";

        public static string FeatureNotFound => "Featured item not found.";
        public static string InvalidFeatureId => "Invalid featured item ID.";

        public static string InvalidStartDate => "Invalid start date.";
        public static string InvalidEndDate => "Invalid end date.";

        public static string FeatureListed => "Featured items listed successfully.";
        public static string FeaturesNotFound => "Featured items not found.";

        public static string FeatureValidationFailed => "Featured item validation failed.";
    }
}
