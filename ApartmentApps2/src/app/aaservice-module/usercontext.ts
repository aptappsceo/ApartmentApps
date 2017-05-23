import { Injectable} from '@angular/core';
import {UserInfoViewModel} from './aaclient'

@Injectable()
export class UserContext {
    public UserToken: string;
    public UserInfo: UserInfoViewModel = new UserInfoViewModel();
}
 