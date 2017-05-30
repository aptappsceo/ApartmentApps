import { Observable } from 'rxjs';
import {Headers, RequestOptions, Http, Response} from '@angular/http';
import { Injectable } from '@angular/core';
import {Encode} from "../../utils/url-encoder";
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
