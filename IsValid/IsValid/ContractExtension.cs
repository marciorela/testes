using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IsValid
{
    public static class ContractExtension
    {
        public static Contract IsEmail(this Contract contract, string value, string propertyName, string message = "E-mail inválido.")
        {
            Regex rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            //Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (!rg.IsMatch(value))
            {
                contract.AddNotification(propertyName, message);
            }
            return contract;
        }

        public static Contract IsTrue(this Contract contract, bool value, string propertyName, string message)
        {
            if (!value)
            {
                contract.AddNotification(propertyName, message);
            }
            return contract;
        }

        public static Contract IsLengthGreaterThan(this Contract contract, string value, int length, string propertyName, string message)
        {
            if (value.Length <= length)
            {
                contract.AddNotification(propertyName, message);
            }
            return contract;
        }

        public static Contract IsLengthGreaterOrEqualThan(this Contract contract, string value, int length, string propertyName, string message)
        {
            if (value.Length < length)
            {
                contract.AddNotification(propertyName, message);
            }
            return contract;
        }

        public static Contract IsLengthLessThan(this Contract contract, string value, int length, string propertyName, string message)
        {
            if (value.Length >= length)
            {
                contract.AddNotification(propertyName, message);
            }
            return contract;
        }

        public static Contract IsLengthLessOrEqualThan(this Contract contract, string value, int length, string propertyName, string message)
        {
            if (value.Length > length)
            {
                contract.AddNotification(propertyName, message);
            }
            return contract;
        }

        public static Contract IsLengthEqual(this Contract contract, string value, int length, string propertyName, string message)
        {
            if (value.Length != length)
            {
                contract.AddNotification(propertyName, message);
            }
            return contract;
        }

        public static Contract IsUF(this Contract contract, string value, string propertyName, string message = "UF inválida.")
        {
            value = value.Replace(",", "");
            if (!value.Contains("AC,AL,AP,AM,BA,CE,DF,ES,GO,MA,MT,MS,MG,PA,PB,PR,PE,PI,RJ,RN,RS,RO,RR,SC,SP,SE,TO"))
            {
                contract.AddNotification(propertyName, message);
            }
            return contract;
        }

        public static Contract IsDocumentCpf(this Contract contract, string value, string propertyName, string message = "CPF inválido.")
        {
            return contract;
        }

    }
}
