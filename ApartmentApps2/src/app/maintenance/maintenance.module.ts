import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateWorkOrderComponent } from './create-work-order/create-work-order.component';
import { AAServiceModule } from './../aaservice-module/aaservice.module';
@NgModule({
  imports: [
    CommonModule,
    AAServiceModule
  ],
  exports: [
    CreateWorkOrderComponent
  ],
  declarations: [CreateWorkOrderComponent]
})
export class MaintenanceModule { }
