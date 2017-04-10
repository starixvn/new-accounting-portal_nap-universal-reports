using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniversalReports.Core.Factory
{
    public static class CriteriaFactory
    {
        public static T Transform<T>(object value) where T : class
        {
            var settingProperties = typeof(T).GetProperties(
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            var gettingProperties = value.GetType().GetProperties(
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            var instance = (T)Activator.CreateInstance(typeof(T));
            foreach (var property in settingProperties)
            {
                SetPropertyValue(instance, value, property, gettingProperties);
            }

            return instance;
        }

        private static void SetPropertyValue(object settingObject, object gettingObject, PropertyInfo settingProperty, IEnumerable<PropertyInfo> gettingProperties)
        {
            var gettingProperty = gettingProperties.SingleOrDefault(p => p.Name == settingProperty.Name);
            if (gettingProperty == null)
            {
                return;
            }

            var value = gettingProperty.GetValue(gettingObject);
            settingProperty.SetValue(settingObject, value);
        }
    }
}