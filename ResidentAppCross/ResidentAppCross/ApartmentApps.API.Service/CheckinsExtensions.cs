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
    public static partial class CheckinsExtensions
    {
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICheckins.
        /// </param>
        public static IList<CourtesyCheckinBindingModel> Get(this ICheckins operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ICheckins)s).GetAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICheckins.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<CourtesyCheckinBindingModel>> GetAsync(this ICheckins operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<ApartmentApps.Client.Models.CourtesyCheckinBindingModel>> result = await operations.GetWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICheckins.
        /// </param>
        /// <param name='locationId'>
        /// Required.
        /// </param>
        public static object Post(this ICheckins operations, int locationId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ICheckins)s).PostAsync(locationId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICheckins.
        /// </param>
        /// <param name='locationId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> PostAsync(this ICheckins operations, int locationId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.PostWithOperationResponseAsync(locationId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
