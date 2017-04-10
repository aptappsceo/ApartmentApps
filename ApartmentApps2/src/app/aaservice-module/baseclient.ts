import 'rxjs/Rx'; 
import { Observable } from 'rxjs/Observable';
import { Injectable, Inject, Optional, OpaqueToken } from '@angular/core';
import { Http, Headers, Response, RequestOptionsArgs,RequestOptions } from '@angular/http';
import {Encode} from "../../utils/url-encoder";
//import {AppConfig} from "../../appconfig";
import { AccountClient } from './aaclient';


@Injectable()
export class UserContext {
    public UserToken: string;

}

@Injectable()
export class BaseClient {
    constructor(private userContext : UserContext) {

    }
    transformOptions(options: RequestOptionsArgs) {
     console.log('options hit');
        options.headers.append("Authorization", "Bearer ");

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
      return this.http.post('http://api.apartmentapps.com/Token', Encode(payload), options);

  }


}
@Injectable()
export class UserService {
    //
    public constructor( @Inject(UserContext)public userContext:UserContext
    , @Inject(AuthClient) private authClient:AuthClient
    , @Inject(AccountClient) private accountClient:AccountClient
    ) {


    }
    public Authenticate(username:string,password:string) : Promise<any> {
        return new Promise((ok,err)=>{
            this.authClient.authenticate(username, password)
                .subscribe((res:any)=>{
                     var result = JSON.parse(res._body);
                     console.log("RESULT" ,result);
                     if (result.error == "invalid_grant") {
                         err(result.error_description);
                     } else {
                                this.userContext.UserToken = result.access_token;
                        ok(res);
                     }
                    console.log("Login Response", res);
                    
                },(x)=>{
                    err(x);
                });
        });
    }
    public Login(username:string,password:string) : Promise<any> {
        return this.Authenticate(username,password)
            .then((v)=>{
                // return new Promise((ok,err)=>{
                //     this.accountClient.getUserInfo("portal", null)
                //         .subscribe(x=>{
                //             console.log(x);
                //             ok(x);
                //          });
                // });
                
            },(v)=>{ console.log(v); });
    }

}