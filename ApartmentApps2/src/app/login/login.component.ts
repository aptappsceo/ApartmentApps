import { Component, ViewEncapsulation, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { UserService } from '../aaservice-module/user.service';

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
  constructor(@Inject(UserService) private userService:UserService, @Inject(Router) private router:Router) {
    
  }
  public login() {
    this.userService.Login(this.username,this.password)
    .then((v)=>{
       this.router.navigate(['/app']);
        console.log(v);
        
    }).catch(reason=>{ 
      alert("Username or password is invalid.")
    });
  }
}
