﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using PlaygroundConsole;
using PlaygroundConsole.Models;

namespace PlaygroundConsole
{
    public static partial class AccountExtensions
    {
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        public static string AddExternalLogin(this IAccount operations, AddExternalLoginBindingModel model)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).AddExternalLoginAsync(model);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> AddExternalLoginAsync(this IAccount operations, AddExternalLoginBindingModel model, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.AddExternalLoginWithOperationResponseAsync(model, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        public static string ChangePassword(this IAccount operations, ChangePasswordBindingModel model)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).ChangePasswordAsync(model);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> ChangePasswordAsync(this IAccount operations, ChangePasswordBindingModel model, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.ChangePasswordWithOperationResponseAsync(model, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='provider'>
        /// Required.
        /// </param>
        /// <param name='error'>
        /// Optional.
        /// </param>
        public static string GetExternalLogin(this IAccount operations, string provider, string error = null)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).GetExternalLoginAsync(provider, error);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='provider'>
        /// Required.
        /// </param>
        /// <param name='error'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> GetExternalLoginAsync(this IAccount operations, string provider, string error = null, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.GetExternalLoginWithOperationResponseAsync(provider, error, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='returnUrl'>
        /// Required.
        /// </param>
        /// <param name='generateState'>
        /// Optional.
        /// </param>
        public static IList<ExternalLoginViewModel> GetExternalLogins(this IAccount operations, string returnUrl, bool? generateState = null)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).GetExternalLoginsAsync(returnUrl, generateState);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='returnUrl'>
        /// Required.
        /// </param>
        /// <param name='generateState'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<ExternalLoginViewModel>> GetExternalLoginsAsync(this IAccount operations, string returnUrl, bool? generateState = null, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<PlaygroundConsole.Models.ExternalLoginViewModel>> result = await operations.GetExternalLoginsWithOperationResponseAsync(returnUrl, generateState, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='returnUrl'>
        /// Required.
        /// </param>
        /// <param name='generateState'>
        /// Optional.
        /// </param>
        public static ManageInfoViewModel GetManageInfo(this IAccount operations, string returnUrl, bool? generateState = null)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).GetManageInfoAsync(returnUrl, generateState);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='returnUrl'>
        /// Required.
        /// </param>
        /// <param name='generateState'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<ManageInfoViewModel> GetManageInfoAsync(this IAccount operations, string returnUrl, bool? generateState = null, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<PlaygroundConsole.Models.ManageInfoViewModel> result = await operations.GetManageInfoWithOperationResponseAsync(returnUrl, generateState, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        public static UserInfoViewModel GetUserInfo(this IAccount operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).GetUserInfoAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<UserInfoViewModel> GetUserInfoAsync(this IAccount operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<PlaygroundConsole.Models.UserInfoViewModel> result = await operations.GetUserInfoWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        public static string Logout(this IAccount operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).LogoutAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> LogoutAsync(this IAccount operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.LogoutWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        public static string Register(this IAccount operations, RegisterBindingModel model)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).RegisterAsync(model);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> RegisterAsync(this IAccount operations, RegisterBindingModel model, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.RegisterWithOperationResponseAsync(model, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        public static string RegisterExternal(this IAccount operations, RegisterExternalBindingModel model)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).RegisterExternalAsync(model);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> RegisterExternalAsync(this IAccount operations, RegisterExternalBindingModel model, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.RegisterExternalWithOperationResponseAsync(model, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        public static string RemoveLogin(this IAccount operations, RemoveLoginBindingModel model)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).RemoveLoginAsync(model);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> RemoveLoginAsync(this IAccount operations, RemoveLoginBindingModel model, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.RemoveLoginWithOperationResponseAsync(model, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        public static string SetPassword(this IAccount operations, SetPasswordBindingModel model)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IAccount)s).SetPasswordAsync(model);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the PlaygroundConsole.IAccount.
        /// </param>
        /// <param name='model'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> SetPasswordAsync(this IAccount operations, SetPasswordBindingModel model, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.SetPasswordWithOperationResponseAsync(model, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}