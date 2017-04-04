import 'rxjs/Rx'; 
import { Observable } from 'rxjs/Observable';
import { Injectable, Inject, Optional, OpaqueToken } from '@angular/core';
import { Http, Headers, Response, RequestOptionsArgs,RequestOptions } from '@angular/http';
import {Encode} from "../../utils/url-encoder";

@Injectable()
export class BaseClient {
    constructor() {

    }
    transformOptions(options) {
        
    }
}


import {AppConfig} from "../../appconfig";

@Injectable()
export class AuthClient {

  constructor(public http : Http, public appConfig : AppConfig ){
    console.log('from auth client')
    console.log(http);
  }

  public authenticate(username : string, password : string) : Observable<Response> {

      let headers = new Headers({'Content-Type': 'application/x-www-form-urlencoded'});
      let options = new RequestOptions({headers: headers});
      let payload = {
        username : username,
        password : password,
        grant_type : 'password'
      };
      return this.http.post(this.appConfig.authEndpoint, Encode(payload), options);

  }


}
