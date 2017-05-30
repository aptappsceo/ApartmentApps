import {OpaqueToken, NgModule, Injectable, Inject} from '@angular/core';
import {XHRBackend, RequestOptions, Http, Headers, Response} from '@angular/http';
import { TokenProvider } from './token_provider';
import { AuthHttp } from './auth-http';
import {
  LookupsClient, MaitenanceClient, SearchEnginesClient,
  QueryResultOfLookupBindingModel, SwaggerException, AccountClient, VersionClient
} from "./generated/backend.generated";
import {AuthClient} from "./auth.client";
import {AppConfig} from "../../appconfig";
import {Observable} from "rxjs";
export const AUTH_HTTP = new OpaqueToken('AUTH_HTTP');



export function authHttpFactory(backend: XHRBackend,
                                defaultOptions: RequestOptions,
                                tokenProvider : TokenProvider) {
  return new AuthHttp(backend, defaultOptions,tokenProvider);
}

@Injectable()
export class Backend {

  public maintenance : MaitenanceClient;
  public lookups : LookupsClient;
  public searchEngines: SearchEnginesClient;
  public account : AccountClient;
  public version : VersionClient;
  private http : Http;

  constructor(@Inject(AUTH_HTTP) http : Http, public authClient : AuthClient, public appConfig : AppConfig){
    this.http = http;

    //react to endpoint change and reinitialize clients
    appConfig.endpointProperty.subscribe(endpoint => {
      this.maintenance = new MaitenanceClient(this.http,endpoint);
      this.lookups = new LookupsClient(this.http,endpoint);
      this.searchEngines = new SearchEnginesClient(this.http,endpoint);
      this.version = new VersionClient(this.http,endpoint);
      this.account = new AccountClient(this.http,endpoint);
    });
  }


  public lookup(datasource : string, query: string): Observable<QueryResultOfLookupBindingModel> {

    let url_ = datasource+"?";
    if (query !== undefined)
      url_ += "query=" + encodeURIComponent("" + query) + "&";

    const content_ = "";

    return this.http.request(url_, {
      body: content_,
      method: "get",
      headers: new Headers({
        "Content-Type": "application/json; charset=UTF-8"
      })
    }).map((response) => {
      return this.processLookup(response);
    }).catch((response: any, caught: any) => {
      if (response instanceof Response) {
        try {
          return Observable.of(this.processLookup(response));
        } catch (e) {
          return <Observable<QueryResultOfLookupBindingModel>><any>Observable.throw(e);
        }
      } else
        return <Observable<QueryResultOfLookupBindingModel>><any>Observable.throw(response);
    });
  }

  protected processLookup(response: Response): QueryResultOfLookupBindingModel {
    const responseText = response.text();
    const status = response.status;

    if (status === 200) {
      let result200: QueryResultOfLookupBindingModel = null;
      let resultData200 = responseText === "" ? null : JSON.parse(responseText);
      result200 = resultData200 ? QueryResultOfLookupBindingModel.fromJS(resultData200) : new QueryResultOfLookupBindingModel();
      return result200;
    } else if (status !== 200 && status !== 204) {
      this.throwException("An unexpected server error occurred.", status, responseText);
    }
    return null;
  }

  protected throwException(message: string, status: number, response: string, result?: any): any {
    if(result !== null && result !== undefined)
      throw result;
    else
      throw new SwaggerException(message, status, response);
  }


}


@NgModule({
  declarations : [],
  providers: [
    {
      provide: AUTH_HTTP,
      useFactory: authHttpFactory,
      deps: [XHRBackend, RequestOptions, TokenProvider]
    },
    TokenProvider,
    Backend,
  ]
})
export class BackendModule {
}
