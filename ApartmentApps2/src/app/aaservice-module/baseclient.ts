import 'rxjs/Rx'; 
import { Observable } from 'rxjs/Observable';
import { Injectable, Inject, Optional, OpaqueToken } from '@angular/core';
import { Http, Headers, Response, RequestOptionsArgs,RequestOptions } from '@angular/http';
import {Encode} from "../../utils/url-encoder";
//import {AppConfig} from "../../appconfig";
import { UserContext } from './usercontext';
import { IAccountClient, AccountClient } from './aaclient';

@Injectable()
export class BaseClient {
    constructor(private userContext : UserContext) {

    }
    transformOptions(options: RequestOptionsArgs) {
     console.log('options hit');
        options.headers.append("Authorization", "Bearer " + this.userContext.UserToken);

        return Promise.resolve(options);
    }
    
}




@Injectable()
export class AuthClient {

  constructor(public http : Http){
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
      console.log("logging in", payload);
      return this.http.post('http://devservices.localhost.com/Token', Encode(payload), options);

  }


}
