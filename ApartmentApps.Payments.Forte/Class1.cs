using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApartmentApps.Payments.Forte.Forte.Transaction;

namespace ApartmentApps.Payments.Forte
{
    public class ExecuteSocketQueryParams
    {
        public ExecuteSocketQueryParams()
        {

        }
        public ExecuteSocketQueryParams(string pg_merchant_id, string pg_password, string pg_transaction_type, string pg_merchant_data_1, string pg_merchant_data_2, string pg_merchant_data_3, string pg_merchant_data_4, string pg_merchant_data_5, string pg_merchant_data_6, string pg_merchant_data_7, string pg_merchant_data_8, string pg_merchant_data_9, string pg_total_amount, string pg_sales_tax_amount, string pg_convenience_fee, string pg_consumer_id, string ecom_consumerorderid, string ecom_walletid, string pg_billto_postal_name_company, string ecom_billto_postal_name_first, string ecom_billto_postal_name_last, string ecom_billto_postal_street_line1, string ecom_billto_postal_street_line2, string ecom_billto_postal_city, string ecom_billto_postal_stateprov, string ecom_billto_postal_postalcode, string ecom_billto_postal_countrycode, string ecom_billto_telecom_phone_number, string ecom_billto_online_email, string pg_billto_ssn, string pg_billto_dl_number, string pg_billto_dl_state, string pg_billto_date_of_birth, string pg_entered_by, string pg_schedule_quantity, string pg_schedule_frequency, string pg_schedule_recurring_amount, string pg_schedule_start_date, string pg_customer_ip_address, string pg_preauth_no_decline_on_fail, string pg_preauth_decline_on_noanswer, string pg_avs_method, string ecom_payment_card_type, string ecom_payment_card_name, string ecom_payment_card_number, string ecom_payment_card_expdate_month, string ecom_payment_card_expdate_year, string ecom_payment_card_verification, string pg_procurement_card, string pg_customer_acct_code, string pg_cc_swipe_data, string pg_mail_or_phone_order, string ecom_payment_check_trn, string ecom_payment_check_account, string ecom_payment_check_account_type, string ecom_payment_check_checkno, string pg_original_trace_number, string pg_original_authorization_code, string pg_client_id, string pg_payment_method_id, string pg_entry_class_code)
        {
            PgMerchantId = pg_merchant_id;
            PgPassword = pg_password;
            PgTransactionType = pg_transaction_type;
            PgMerchantData1 = pg_merchant_data_1;
            PgMerchantData2 = pg_merchant_data_2;
            PgMerchantData3 = pg_merchant_data_3;
            PgMerchantData4 = pg_merchant_data_4;
            PgMerchantData5 = pg_merchant_data_5;
            PgMerchantData6 = pg_merchant_data_6;
            PgMerchantData7 = pg_merchant_data_7;
            PgMerchantData8 = pg_merchant_data_8;
            PgMerchantData9 = pg_merchant_data_9;
            PgTotalAmount = pg_total_amount;
            PgSalesTaxAmount = pg_sales_tax_amount;
            PgConvenienceFee = pg_convenience_fee;
            PgConsumerId = pg_consumer_id;
            EcomConsumerorderid = ecom_consumerorderid;
            EcomWalletid = ecom_walletid;
            PgBilltoPostalNameCompany = pg_billto_postal_name_company;
            EcomBilltoPostalNameFirst = ecom_billto_postal_name_first;
            EcomBilltoPostalNameLast = ecom_billto_postal_name_last;
            EcomBilltoPostalStreetLine1 = ecom_billto_postal_street_line1;
            EcomBilltoPostalStreetLine2 = ecom_billto_postal_street_line2;
            EcomBilltoPostalCity = ecom_billto_postal_city;
            EcomBilltoPostalStateprov = ecom_billto_postal_stateprov;
            EcomBilltoPostalPostalcode = ecom_billto_postal_postalcode;
            EcomBilltoPostalCountrycode = ecom_billto_postal_countrycode;
            EcomBilltoTelecomPhoneNumber = ecom_billto_telecom_phone_number;
            EcomBilltoOnlineEmail = ecom_billto_online_email;
            PgBilltoSsn = pg_billto_ssn;
            PgBilltoDlNumber = pg_billto_dl_number;
            PgBilltoDlState = pg_billto_dl_state;
            PgBilltoDateOfBirth = pg_billto_date_of_birth;
            PgEnteredBy = pg_entered_by;
            PgScheduleQuantity = pg_schedule_quantity;
            PgScheduleFrequency = pg_schedule_frequency;
            PgScheduleRecurringAmount = pg_schedule_recurring_amount;
            PgScheduleStartDate = pg_schedule_start_date;
            PgCustomerIpAddress = pg_customer_ip_address;
            PgPreauthNoDeclineOnFail = pg_preauth_no_decline_on_fail;
            PgPreauthDeclineOnNoanswer = pg_preauth_decline_on_noanswer;
            PgAvsMethod = pg_avs_method;
            EcomPaymentCardType = ecom_payment_card_type;
            EcomPaymentCardName = ecom_payment_card_name;
            EcomPaymentCardNumber = ecom_payment_card_number;
            EcomPaymentCardExpdateMonth = ecom_payment_card_expdate_month;
            EcomPaymentCardExpdateYear = ecom_payment_card_expdate_year;
            EcomPaymentCardVerification = ecom_payment_card_verification;
            PgProcurementCard = pg_procurement_card;
            PgCustomerAcctCode = pg_customer_acct_code;
            PgCcSwipeData = pg_cc_swipe_data;
            PgMailOrPhoneOrder = pg_mail_or_phone_order;
            EcomPaymentCheckTrn = ecom_payment_check_trn;
            EcomPaymentCheckAccount = ecom_payment_check_account;
            EcomPaymentCheckAccountType = ecom_payment_check_account_type;
            EcomPaymentCheckCheckno = ecom_payment_check_checkno;
            PgOriginalTraceNumber = pg_original_trace_number;
            PgOriginalAuthorizationCode = pg_original_authorization_code;
            PgClientId = pg_client_id;
            PgPaymentMethodId = pg_payment_method_id;
            PgEntryClassCode = pg_entry_class_code;
        }

        public string PgMerchantId { get; set; }

        public string PgPassword { get; set; }

        public string PgTransactionType { get; set; }

        public string PgMerchantData1 { get; set; }

        public string PgMerchantData2 { get; }

        public string PgMerchantData3 { get; }

        public string PgMerchantData4 { get; }

        public string PgMerchantData5 { get; }

        public string PgMerchantData6 { get; }

        public string PgMerchantData7 { get; }

        public string PgMerchantData8 { get; }

        public string PgMerchantData9 { get; }

        public string PgTotalAmount { get; set; }

        public string PgSalesTaxAmount { get; set; }

        public string PgConvenienceFee { get; set; }

        public string PgConsumerId { get; set; }

        public string EcomConsumerorderid { get; set; }

        public string EcomWalletid { get; set; }

        public string PgBilltoPostalNameCompany { get; set; }

        public string EcomBilltoPostalNameFirst { get; set; }

        public string EcomBilltoPostalNameLast { get; set; }

        public string EcomBilltoPostalStreetLine1 { get; set; }

        public string EcomBilltoPostalStreetLine2 { get; set; }

        public string EcomBilltoPostalCity { get; set; }

        public string EcomBilltoPostalStateprov { get; set; }

        public string EcomBilltoPostalPostalcode { get; set; }

        public string EcomBilltoPostalCountrycode { get; set; }

        public string EcomBilltoTelecomPhoneNumber { get; set; }

        public string EcomBilltoOnlineEmail { get; set; }

        public string PgBilltoSsn { get; set; }

        public string PgBilltoDlNumber { get; set; }

        public string PgBilltoDlState { get; set; }

        public string PgBilltoDateOfBirth { get; set; }

        public string PgEnteredBy { get; set; }

        public string PgScheduleQuantity { get; set; }

        public string PgScheduleFrequency { get; set; }

        public string PgScheduleRecurringAmount { get; set; }

        public string PgScheduleStartDate { get; set; }

        public string PgCustomerIpAddress { get; set; }

        public string PgPreauthNoDeclineOnFail { get; set; }

        public string PgPreauthDeclineOnNoanswer { get; set; }

        public string PgAvsMethod { get; set; }

        public string EcomPaymentCardType { get; set; }

        public string EcomPaymentCardName { get; set; }

        public string EcomPaymentCardNumber { get; set; }

        public string EcomPaymentCardExpdateMonth { get; set; }

        public string EcomPaymentCardExpdateYear { get; set; }

        public string EcomPaymentCardVerification { get; set; }

        public string PgProcurementCard { get; set; }

        public string PgCustomerAcctCode { get; set; }

        public string PgCcSwipeData { get; set; }

        public string PgMailOrPhoneOrder { get; set; }

        public string EcomPaymentCheckTrn { get; set; }

        public string EcomPaymentCheckAccount { get; set; }

        public string EcomPaymentCheckAccountType { get; set; }

        public string EcomPaymentCheckCheckno { get; set; }

        public string PgOriginalTraceNumber { get; set; }

        public string PgOriginalAuthorizationCode { get; set; }

        public string PgClientId { get; set; }

        public string PgPaymentMethodId { get; set; }

        public string PgEntryClassCode { get; set; }
    }
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
