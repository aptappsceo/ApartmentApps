/*
 * Angular 2 decorators and services
 */
import { Component, ViewEncapsulation, Inject } from '@angular/core';
import { AppState } from './app.service';
import { MaintenanceModule } from './maintenance/maintenance.module';
import { Router } from '@angular/router';
import { UserService } from './aaservice-module/user.service';

/*
 * App Component
 * Top Level Component
 */
@Component({
  selector: 'app',
  encapsulation: ViewEncapsulation.None,
  styleUrls: [
    './scss/application.scss'
  ],
  template: `<router-outlet></router-outlet>`
})
export class App  {

  constructor(
    public appState: AppState,@Inject(Router) private router:Router, private userService:UserService) {

  }

  ngOnInit() {
    console.log('Initial App Statessss', this.appState.state);
    console.log("User Token", this.userService.userContext.UserToken);
    if (this.userService.userContext.UserToken === undefined || this.userService.userContext.UserToken == null) {
      this.router.navigate(['login']);
      console.log("yup");
      //https://stackoverflow.com/questions/34331478/angular2-redirect-to-login-page
      this.router.navigateByUrl('/login');
    }
  }

}
