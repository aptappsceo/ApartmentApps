﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApartmentApps.Client;
using ApartmentApps.Client.Models;
using Microsoft.Rest;

namespace ApartmentApps.Client
{
    public static partial class PaymentsExtensions
    {
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='addBankAccount'>
        /// Required.
        /// </param>
        public static AddBankAccountResult AddBankAccount(this IPayments operations, AddBankAccountBindingModel addBankAccount)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPayments)s).AddBankAccountAsync(addBankAccount);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='addBankAccount'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<AddBankAccountResult> AddBankAccountAsync(this IPayments operations, AddBankAccountBindingModel addBankAccount, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<ApartmentApps.Client.Models.AddBankAccountResult> result = await operations.AddBankAccountWithOperationResponseAsync(addBankAccount, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='addCreditCard'>
        /// Required.
        /// </param>
        public static AddCreditCardResult AddCreditCard(this IPayments operations, AddCreditCardBindingModel addCreditCard)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPayments)s).AddCreditCardAsync(addCreditCard);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='addCreditCard'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<AddCreditCardResult> AddCreditCardAsync(this IPayments operations, AddCreditCardBindingModel addCreditCard, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<ApartmentApps.Client.Models.AddCreditCardResult> result = await operations.AddCreditCardWithOperationResponseAsync(addCreditCard, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        public static IList<string> GetPaymentHistory(this IPayments operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPayments)s).GetPaymentHistoryAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<string>> GetPaymentHistoryAsync(this IPayments operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<string>> result = await operations.GetPaymentHistoryWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        public static IList<PaymentOptionBindingModel> GetPaymentOptions(this IPayments operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPayments)s).GetPaymentOptionsAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<PaymentOptionBindingModel>> GetPaymentOptionsAsync(this IPayments operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<ApartmentApps.Client.Models.PaymentOptionBindingModel>> result = await operations.GetPaymentOptionsWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='paymentOptionId'>
        /// Required.
        /// </param>
        public static PaymentListBindingModel GetPaymentSummary(this IPayments operations, int paymentOptionId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPayments)s).GetPaymentSummaryAsync(paymentOptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='paymentOptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<PaymentListBindingModel> GetPaymentSummaryAsync(this IPayments operations, int paymentOptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<ApartmentApps.Client.Models.PaymentListBindingModel> result = await operations.GetPaymentSummaryWithOperationResponseAsync(paymentOptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        public static PaymentListBindingModel GetRentSummary(this IPayments operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPayments)s).GetRentSummaryAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<PaymentListBindingModel> GetRentSummaryAsync(this IPayments operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<ApartmentApps.Client.Models.PaymentListBindingModel> result = await operations.GetRentSummaryWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='makePaymentBindingModel'>
        /// Required.
        /// </param>
        public static MakePaymentResult MakePayment(this IPayments operations, MakePaymentBindingModel makePaymentBindingModel)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IPayments)s).MakePaymentAsync(makePaymentBindingModel);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IPayments.
        /// </param>
        /// <param name='makePaymentBindingModel'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<MakePaymentResult> MakePaymentAsync(this IPayments operations, MakePaymentBindingModel makePaymentBindingModel, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<ApartmentApps.Client.Models.MakePaymentResult> result = await operations.MakePaymentWithOperationResponseAsync(makePaymentBindingModel, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
