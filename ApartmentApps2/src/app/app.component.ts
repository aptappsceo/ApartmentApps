/*
 * Angular 2 decorators and services
 */
import { Component, ViewEncapsulation } from '@angular/core';
import { AppState } from './app.service';
import { MaintenanceModule } from './maintenance/maintenance.module';

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
export class App {

  constructor(
    public appState: AppState) {

  }

  ngOnInit() {
    console.log('Initial App Statessss', this.appState.state);
  }

}
