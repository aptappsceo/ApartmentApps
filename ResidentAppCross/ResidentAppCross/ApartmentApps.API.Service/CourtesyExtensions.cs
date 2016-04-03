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
    public static partial class CourtesyExtensions
    {
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='unitId'>
        /// Required.
        /// </param>
        public static object AssignUnitToIncidentReport(this ICourtesy operations, int id, int unitId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ICourtesy)s).AssignUnitToIncidentReportAsync(id, unitId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='unitId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> AssignUnitToIncidentReportAsync(this ICourtesy operations, int id, int unitId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.AssignUnitToIncidentReportWithOperationResponseAsync(id, unitId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='comments'>
        /// Required.
        /// </param>
        /// <param name='images'>
        /// Required.
        /// </param>
        public static object CloseIncidentReport(this ICourtesy operations, int id, string comments, IList<string> images)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ICourtesy)s).CloseIncidentReportAsync(id, comments, images);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
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
        public static async Task<object> CloseIncidentReportAsync(this ICourtesy operations, int id, string comments, IList<string> images, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.CloseIncidentReportWithOperationResponseAsync(id, comments, images, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static IncidentReportBindingModel Get(this ICourtesy operations, int id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ICourtesy)s).GetAsync(id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IncidentReportBindingModel> GetAsync(this ICourtesy operations, int id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<ApartmentApps.Client.Models.IncidentReportBindingModel> result = await operations.GetWithOperationResponseAsync(id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        public static IList<IncidentIndexBindingModel> ListRequests(this ICourtesy operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ICourtesy)s).ListRequestsAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<IncidentIndexBindingModel>> ListRequestsAsync(this ICourtesy operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<ApartmentApps.Client.Models.IncidentIndexBindingModel>> result = await operations.ListRequestsWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='comments'>
        /// Required.
        /// </param>
        /// <param name='images'>
        /// Required.
        /// </param>
        public static object OpenIncidentReport(this ICourtesy operations, int id, string comments, IList<string> images)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ICourtesy)s).OpenIncidentReportAsync(id, comments, images);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
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
        public static async Task<object> OpenIncidentReportAsync(this ICourtesy operations, int id, string comments, IList<string> images, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.OpenIncidentReportWithOperationResponseAsync(id, comments, images, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='comments'>
        /// Required.
        /// </param>
        /// <param name='images'>
        /// Required.
        /// </param>
        public static object PauseIncidentReport(this ICourtesy operations, int id, string comments, IList<string> images)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ICourtesy)s).PauseIncidentReportAsync(id, comments, images);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
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
        public static async Task<object> PauseIncidentReportAsync(this ICourtesy operations, int id, string comments, IList<string> images, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.PauseIncidentReportWithOperationResponseAsync(id, comments, images, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='request'>
        /// Required.
        /// </param>
        public static object SubmitIncidentReport(this ICourtesy operations, IncidentReportModel request)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ICourtesy)s).SubmitIncidentReportAsync(request);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the ApartmentApps.Client.ICourtesy.
        /// </param>
        /// <param name='request'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> SubmitIncidentReportAsync(this ICourtesy operations, IncidentReportModel request, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.SubmitIncidentReportWithOperationResponseAsync(request, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
