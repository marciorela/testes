using System;
using System.Collections.Generic;
using System.Linq;

namespace IsValid
{
    public class Funcionario : Notifiable
    {
        public string Email { get; set; } = "";

        public Funcionario()
        {
        }

        internal void ShowNotifications()
        {
            Validate();

            foreach (var n in Notifications)
            {
                Console.WriteLine(n.Message);
            }
        }

        public override void Validate()
        {
            AddNotification(new Contract()
                .Requires()
                .IsEmail(Email, "Email")
            );
        }

    }

}