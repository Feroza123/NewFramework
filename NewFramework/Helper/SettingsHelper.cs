using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewFramework.Settings;

namespace NewFramework.Helper
{
    public static class SettingsHelper
    {
        public static T GetValue<T>(string settingName)
        {
            T returnValue;
            try
            {
                returnValue = (T) Convert.ChangeType(Settings.Settings.ResourceManager.GetObject(settingName), typeof(T));
            }
            catch(Exception)
            {
                throw new Exception($"Error, unable to find setting {settingName}, check the settings file");
            }

            return returnValue;
        }
    }
}
