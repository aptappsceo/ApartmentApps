import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateWorkOrderComponent } from './create-work-order/create-work-order.component';
import { MaintenancePageComponent } from './maintenance-page/maintenance-page.component';
import { MaintenanceFormComponent } from './maintenance-form/maintenance-form.component';
import { MaintenanceDetailsPageComponent } from './maintenance-details-page/maintenance-details-page.component';
import { RouterModule } from '@angular/router';
import { WidgetsModule } from "app/widgets/widgets.module";
import { AACoreModule } from "app/aacore/aacore.module";
export const routes = [
  // { path: 'checkins', component: MaintenanceFormComponent },
  { path: 'workorders', component: MaintenancePageComponent },
  { path: 'workorders/:id', component: MaintenanceDetailsPageComponent },
];
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    WidgetsModule,
    AACoreModule
  ],
  exports: [
    CreateWorkOrderComponent
  ],
  declarations: [CreateWorkOrderComponent, MaintenancePageComponent, MaintenanceFormComponent, MaintenanceDetailsPageComponent]
})
export class MaintenanceModule {   static routes = routes; }
