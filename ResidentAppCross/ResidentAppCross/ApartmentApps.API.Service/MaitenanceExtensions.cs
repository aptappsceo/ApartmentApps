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
        public static IList<MaitenanceRequestType> GetMaitenanceRequestTypes(this IMaitenance operations)
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
        public static async Task<IList<MaitenanceRequestType>> GetMaitenanceRequestTypesAsync(this IMaitenance operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<ApartmentApps.Client.Models.MaitenanceRequestType>> result = await operations.GetMaitenanceRequestTypesWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.IMaitenance.
        /// </param>
        /// <param name='request'>
        /// Required.
        /// </param>
        public static MaitenanceRequest SubmitRequest(this IMaitenance operations, MaitenanceRequestFormModel request)
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
        public static async Task<MaitenanceRequest> SubmitRequestAsync(this IMaitenance operations, MaitenanceRequestFormModel request, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<ApartmentApps.Client.Models.MaitenanceRequest> result = await operations.SubmitRequestWithOperationResponseAsync(request, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
