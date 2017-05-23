import 'rxjs/Rx'; 
import { Observable } from 'rxjs/Observable';
import { Injectable, Inject, Optional, OpaqueToken } from '@angular/core';
import { UserContext } from './usercontext';
import { AuthClient } from './baseclient';
import { AccountClient } from './aaclient';


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
                return new Promise((ok,err)=>{
                    this.accountClient.getUserInfo("portal", null)
                        .subscribe(x=>{
                            console.log(x);
                            this.userContext.UserInfo = x;
                            ok(x);
                         });
                });
                
            },(v)=>{ console.log(v); });
    }

}