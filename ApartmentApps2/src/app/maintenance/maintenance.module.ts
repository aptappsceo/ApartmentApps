import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateWorkOrderComponent } from './create-work-order/create-work-order.component';
import { MaintenancePageComponent } from './maintenance-page/maintenance-page.component';
import { MaintenanceFormComponent } from './maintenance-form/maintenance-form.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    CreateWorkOrderComponent
  ],
  declarations: [CreateWorkOrderComponent, MaintenancePageComponent, MaintenanceFormComponent]
})
export class MaintenanceModule { }
