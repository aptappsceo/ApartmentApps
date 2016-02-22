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
    public static partial class MaitenanceExtensions
    {
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IMaitenance.
        /// </param>
        /// <param name='workerId'>
        /// Required.
        /// </param>
        public static IList<MaitenanceRequest> GetByResident(this IMaitenance operations, string workerId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IMaitenance)s).GetByResidentAsync(workerId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IMaitenance.
        /// </param>
        /// <param name='workerId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<MaitenanceRequest>> GetByResidentAsync(this IMaitenance operations, string workerId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<ApartmentApps.Client.Models.MaitenanceRequest>> result = await operations.GetByResidentWithOperationResponseAsync(workerId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IMaitenance.
        /// </param>
        public static IList<LookupPairModel> GetMaitenanceRequestTypes(this IMaitenance operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IMaitenance)s).GetMaitenanceRequestTypesAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IMaitenance.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<LookupPairModel>> GetMaitenanceRequestTypesAsync(this IMaitenance operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<ApartmentApps.Client.Models.LookupPairModel>> result = await operations.GetMaitenanceRequestTypesWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IMaitenance.
        /// </param>
        /// <param name='workerId'>
        /// Required.
        /// </param>
        public static IList<MaitenanceRequest> GetWorkOrders(this IMaitenance operations, string workerId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IMaitenance)s).GetWorkOrdersAsync(workerId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IMaitenance.
        /// </param>
        /// <param name='workerId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<MaitenanceRequest>> GetWorkOrdersAsync(this IMaitenance operations, string workerId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<ApartmentApps.Client.Models.MaitenanceRequest>> result = await operations.GetWorkOrdersWithOperationResponseAsync(workerId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IMaitenance.
        /// </param>
        /// <param name='request'>
        /// Required.
        /// </param>
        public static object SubmitRequest(this IMaitenance operations, MaitenanceRequestModel request)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IMaitenance)s).SubmitRequestAsync(request);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IMaitenance.
        /// </param>
        /// <param name='request'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> SubmitRequestAsync(this IMaitenance operations, MaitenanceRequestModel request, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.SubmitRequestWithOperationResponseAsync(request, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}