﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApartmentApps.Client.Models;
using Microsoft.Rest;

namespace ApartmentApps.Client
{
    public partial interface IMaitenance
    {
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='comments'>
        /// Required.
        /// </param>
        /// <param name='images'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> CompleteRequestWithOperationResponseAsync(int id, string comments, IList<string> images, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<MaintenanceBindingModel>> GetWithOperationResponseAsync(int id, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='workerId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<MaitenanceRequest>>> GetByResidentWithOperationResponseAsync(string workerId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<LookupPairModel>>> GetMaitenanceRequestTypesWithOperationResponseAsync(CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='workerId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<MaitenanceRequest>>> GetWorkOrdersWithOperationResponseAsync(string workerId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='comments'>
        /// Required.
        /// </param>
        /// <param name='images'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> PauseRequestWithOperationResponseAsync(int id, string comments, IList<string> images, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='request'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> SubmitRequestWithOperationResponseAsync(MaitenanceRequestModel request, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}
