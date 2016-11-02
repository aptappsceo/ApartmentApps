﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApartmentApps.Client.Models;
using Microsoft.Rest;

namespace ApartmentApps.Client
{
    public partial interface IProspect
    {
        /// <param name='base64Image'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<ScanIdResult>> ScanIdWithOperationResponseAsync(string base64Image, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        
        /// <param name='vm'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<string>> SubmitApplicantWithOperationResponseAsync(ProspectApplicationBindingModel vm, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}