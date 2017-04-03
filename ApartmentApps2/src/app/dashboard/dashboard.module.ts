import { NgModule }      from '@angular/core';
import { CommonModule }  from '@angular/common';

import { RouterModule } from '@angular/router';
import { Dashboard } from './dashboard.component.ts';

import { Widget } from '../layout/widget/widget.directive';
import { MaintenanceModule } from '../maintenance/maintenance.module';

export const routes = [
  { path: '', component: Dashboard, pathMatch: 'full' }
];


@NgModule({
  imports: [ CommonModule, RouterModule.forChild(routes), MaintenanceModule ],
  declarations: [ Dashboard, Widget ]
})
export class DashboardModule {
  static routes = routes;
}
