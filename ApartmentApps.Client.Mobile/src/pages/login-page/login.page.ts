import {Component} from '@angular/core';
import {FormGroup, FormBuilder} from '@angular/forms';
import {NavParams, ViewController} from 'ionic-angular';
import {LoadingService} from '../../services/loading.service';
import {ToastService} from '../../services/toast.service';
import {Backend} from "../../services/backend/backend-module";
@Component({
  templateUrl: 'login.page.html',
  selector: 'login-page-component'
})

export class LoginPageComponent {

  public model: FormGroup;
  private apicall : (username:string,password:string)=>Promise<any>;
  private callback: any;

  constructor(public navParams: NavParams,
              public toastService: ToastService,
              public loadingService: LoadingService,
              public formBuilder : FormBuilder,
              public viewCtrl : ViewController,
              public backend : Backend) {

    this.apicall = navParams.get('apicall');
    this.callback = navParams.get('callback');

    this.model = this.formBuilder.group({
      'username' : ['micahosborne@gmail.com'],
      'password' : ['micah123'],
    });

  }

  public authenticate(model: any) {
    this.loadingService.push('Logging in...').then(_ => {
      return this.apicall(model.username, model.password);
    }).then(response => {
      this.loadingService.pop();
      return response;
    }).then(response => {
      this.toastService.show('Authenticated.');
      return response;
    }).then(response => {
      if (this.callback) this.callback(response);
      return this.viewCtrl.dismiss();
    }).catch(er => {
      this.loadingService.pop();
      this.toastService.show('Authentication failed.');
      console.error(er);
    });
  }

}
