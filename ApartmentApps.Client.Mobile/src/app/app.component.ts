import { Component, ViewChild } from '@angular/core';
import { Nav, Platform } from 'ionic-angular';
import { StatusBar, Splashscreen } from 'ionic-native';

import {BlankPageComponent} from "../pages/blank-page/blank.page";
import {IdentityService} from "../services/identity.service";
import {MaintenanceRequestAddPageComponent} from "../pages/maintenance/maintenance-request-add-page/maintenance-request-add.page";
import {MaintenanceRequestIndexPageComponent} from "../pages/maintenance/maintenance-request-index-page/maintenance-request-index.page";


@Component({
  templateUrl: 'app.html'
})
export class AppComponent {
  @ViewChild(Nav) nav: Nav;

  rootPage: any = BlankPageComponent;

  pages: Array<{title: string, component: any}>;

  constructor(public platform: Platform, public identityService : IdentityService) {
    this.initializeApp();

    // used for an example of ngFor and navigation
    this.pages = [
      { title: 'Maintenance Requests', component: MaintenanceRequestIndexPageComponent },
      { title: 'Submit maintenance request...', component: MaintenanceRequestAddPageComponent },
    ];

  }

  initializeApp() {
    this.platform.ready().then(()=>{
      StatusBar.styleDefault();
      Splashscreen.hide();
      }).then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      this.identityService.openAuthentication();
    });
  }

  openPage(page) {
    // Reset the content nav to have just this page
    // we wouldn't want the back button to show in this scenario
    this.nav.setRoot(page.component);
  }
}
