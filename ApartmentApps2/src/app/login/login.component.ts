import { Component, ViewEncapsulation, Inject } from '@angular/core';
import {AccountClient } from './../aaservice-module/aaclient';
import { UserService } from '../aaservice-module/baseclient';
import { FormsModule } from '@angular/forms';

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
  public username:string;
  public password:string;
  constructor(@Inject(UserService) private userService:UserService) {
    
  }
  public login() {
    this.userService.Login(this.username,this.password)
    .then((v)=>{
       
        console.log(v);
        
    });
  }
}
