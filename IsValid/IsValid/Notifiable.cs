using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace IsValid
{
    public class Notifiable
    {
        [NotMapped]
        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public bool IsValid
        {
            get
            {
                Validate();
                return Notifications.Count() == 0;
            }
        }

        public virtual void Validate()
        {
        }

        public void AddNotification(int code, string propertyName, string message)
        {
            Notifications.Add(new Notification()
            {
                Code = code,
                PropertyName = propertyName,
                Message = message
            });
        }

        public void AddNotification(string propertyName, string message)
        {
            Notifications.Add(new Notification()
            {
                Code = 0,
                PropertyName = propertyName,
                Message = message
            });
        }

        public void AddNotification(Contract contract)
        {
            Notifications.Clear();
            Notifications.AddRange(contract.Notifications);
        }

        public void AddNotification(Notifiable object1, Notifiable object2 = null, Notifiable object3 = null)
        {
            Notifications.AddRange(object1.Notifications);

            if (object2 != null) Notifications.AddRange(object2.Notifications);
            if (object3 != null) Notifications.AddRange(object3.Notifications);
        }

        public void AddNotificationAllNotifiableProperties()
        {
            Type objType = this.GetType();
            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (PropertyInfo property in properties)
            {
                if (property.GetType().IsAssignableFrom(typeof(Notifiable)))
                {
                    AddNotification((Notifiable)property.GetValue(this));
                }
            }
        }

    }
}