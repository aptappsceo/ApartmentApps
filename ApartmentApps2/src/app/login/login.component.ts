import { Component, ViewEncapsulation, Inject } from '@angular/core';
import {AccountClient } from './../aaservice-module/aaclient';

@Component({
  selector: 'login',
  styleUrls: [ './login.style.scss' ],
  templateUrl: './login.template.html',
  encapsulation: ViewEncapsulation.None,
  host: {
    class: 'login-page app'
  }
})
export class Login {
  constructor(@Inject(AccountClient) accountClient:AccountClient) {

  }
  public login() {

  }
}
