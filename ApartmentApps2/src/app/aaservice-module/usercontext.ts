import { Injectable} from '@angular/core';
import {UserInfoViewModel} from './aaclient'

@Injectable()
export class UserContext {
    public get UserToken(): string {
        return localStorage.getItem("user_token");
    }
    public set UserToken(value:string) {
        
        if (value == null) {
            localStorage.removeItem("user_token");
        } else {
            localStorage.setItem("user_token", value);
        }
        
    }
    public UserInfo: UserInfoViewModel = null;
    constructor() {
        console.log("CREATED INSTANCE");
    }
}
 