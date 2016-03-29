using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class AparmentAppsDelegating : DelegatingHandler
{
    public static string AuthorizationKey
    {
        get { return App.ApartmentAppsClient.GetAuthToken(); }
        set { App.ApartmentAppsClient.SetAuthToken(value); }
    }


    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Authorization", "Bearer " + AuthorizationKey);
        return base.SendAsync(request, cancellationToken);
    }
}