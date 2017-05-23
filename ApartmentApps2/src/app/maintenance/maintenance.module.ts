import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateWorkOrderComponent } from './create-work-order/create-work-order.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    CreateWorkOrderComponent
  ],
  declarations: [CreateWorkOrderComponent]
})
export class MaintenanceModule { }