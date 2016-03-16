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
    public partial interface ICourtesy
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
        Task<HttpOperationResponse<object>> CloseIncidentReportWithOperationResponseAsync(int id, string comments, IList<string> images, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<IncidentReportBindingModel>> GetWithOperationResponseAsync(int id, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
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
        Task<HttpOperationResponse<object>> OpenIncidentReportWithOperationResponseAsync(int id, string comments, IList<string> images, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
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
        Task<HttpOperationResponse<object>> PauseIncidentReportWithOperationResponseAsync(int id, string comments, IList<string> images, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='request'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> SubmitIncidentReportWithOperationResponseAsync(IncidentReportModel request, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}