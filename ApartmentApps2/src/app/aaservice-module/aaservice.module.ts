import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountClient, MaitenanceClient, MessagingClient, API_BASE_URL } from './aaclient';
import { AuthClient, UserContext, UserService } from './baseclient';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    
  ]
})
export class AAServiceModule {

  static forRoot() : ModuleWithProviders {
    return {
      ngModule: AAServiceModule,
      providers: [
        AuthClient,
        UserContext,
        AccountClient,
        UserService,

        { provide: 'http://api.apartmentapps.com', useValue: API_BASE_URL }
      ]
    };
  }
 }
