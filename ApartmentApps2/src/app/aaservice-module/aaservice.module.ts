import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountClient, MaitenanceClient, MessagingClient, API_BASE_URL } from './aaclient';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    AccountClient,
    { provide: 'http://api.apartmentapps.com', useValue: API_BASE_URL }
  ]
})
export class AAServiceModule { }
