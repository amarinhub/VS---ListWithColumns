using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace ListWithColumns.Features.MasterPage_Feature
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("f8c896cf-7399-4c50-a2c7-ea3b2ab56d6d")]
    public class MasterPage_FeatureEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {

            SPSite currentSite = properties.Feature.Parent as SPSite;
            currentSite.RootWeb.MasterUrl = "/_catalogs/masterpage/Demo.master";
            currentSite.RootWeb.CustomMasterUrl = "/_catalogs/masterpage/Demo.master";

            currentSite.RootWeb.Update();
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite currentSite = properties.Feature.Parent as SPSite;
            currentSite.RootWeb.MasterUrl = "/_catalogs/masterpage/Oslo.master";
            currentSite.RootWeb.CustomMasterUrl = "/_catalogs/masterpage/Oslo.master";

            currentSite.RootWeb.Update();

        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
