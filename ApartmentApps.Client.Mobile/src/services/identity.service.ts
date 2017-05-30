import {Injectable} from '@angular/core';
import {ModalController} from "ionic-angular";
import {LoginPageComponent} from "../pages/login-page/login.page";
import {Response} from "@angular/http";
import 'rxjs/add/operator/toPromise';
import {TokenProvider} from "./backend/token_provider";
import {Backend} from "./backend/backend-module";
import {UserInfoViewModel} from "./backend/generated/backend.generated";
@Injectable()
export class IdentityService {

  public userInfo: UserInfoViewModel;

  constructor(public backend: Backend, public modalCtrl: ModalController, public tokenProvider : TokenProvider) {

  }


  public get isLoggedIn() {
    return !!this.tokenProvider.accessToken;
  };

  public openAuthentication(): Promise<any> {
    return new Promise<Response>((res, rej) => {
      let modal = this.modalCtrl.create(LoginPageComponent, {
        callback: res,
        apicall: (username: string, password: string) => {
          return this.authenticate(username, password);
        }
      });
      modal.present();
    }).then(response => {
      let json = response.json();
      this.tokenProvider.accessToken = json.access_token;
      return this.backend.account.getUserInfo(undefined,undefined).toPromise();
    }).then(userInfo => {
      this.userInfo = userInfo;
    })
  };

  public authenticate(username: string, password: string): Promise<Response> {
    return this.backend.authClient.authenticate(username, password).toPromise();
  }


}
