import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateWorkOrderComponent } from './create-work-order/create-work-order.component';
import { MaintenancePageComponent } from './maintenance-page/maintenance-page.component';
import { MaintenanceFormComponent } from './maintenance-form/maintenance-form.component';
import { MaintenanceDetailsPageComponent } from './maintenance-details-page/maintenance-details-page.component';
import { RouterModule } from '@angular/router';
export const routes = [
  // { path: 'checkins', component: MaintenanceFormComponent },
  { path: 'workorders', component: MaintenancePageComponent },
  { path: 'workorders/:id', component: MaintenanceDetailsPageComponent },
];
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  exports: [
    CreateWorkOrderComponent
  ],
  declarations: [CreateWorkOrderComponent, MaintenancePageComponent, MaintenanceFormComponent, MaintenanceDetailsPageComponent]
})
export class MaintenanceModule {   static routes = routes; }
