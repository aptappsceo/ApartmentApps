using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Payments.Forte.Forte.Transaction;

namespace ApartmentApps.Payments.Forte
{
    public class Authenticate
    {

        public static Authentication GetTransactionAuthTicket(string strAPILoginID, string strKey)
        {
            var ticket = new Forte.Transaction.Authentication
            {
                APILoginID = strAPILoginID,
                UTCTime = DateTime.UtcNow.Ticks.ToString()
            };
            ticket.TSHash = CalculateHMACMD5(ticket.APILoginID + "|" + ticket.UTCTime, strKey.Trim());

            return ticket;
        }

        public static ApartmentApps.Payments.Forte.Forte.Client.Authentication GetClientAuthTicket(string strAPILoginID, string strKey)
        {
            var ticket = new Forte.Client.Authentication
            {
                APILoginID = strAPILoginID,
                UTCTime = DateTime.UtcNow.Ticks.ToString()
            };
            ticket.TSHash = CalculateHMACMD5(ticket.APILoginID + "|" + ticket.UTCTime, strKey.Trim());

            return ticket;
        }

        public static string CalculateHMACMD5(string input, string key)
        {
            StringBuilder sb = new StringBuilder();
            byte[] data = Encoding.Default.GetBytes(input);
            byte[] secretkey = new byte[64];
            secretkey = Encoding.Default.GetBytes(key);
            HMACMD5 hmacMD5 = new HMACMD5(secretkey);
            byte[] macSender = hmacMD5.ComputeHash(data);

            for (int i = 0; i < macSender.Length; i++)
                sb.Append(macSender[i].ToString("x2"));

            return sb.ToString();
        }
    }
    public class Class1
    {
    }
}
