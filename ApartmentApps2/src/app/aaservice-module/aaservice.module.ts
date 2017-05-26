import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountClient, MaitenanceClient, MessagingClient, API_BASE_URL, CourtesyClient } from './aaclient';
import { UserContext } from './usercontext';
import { AuthClient} from './baseclient';
import { UserService } from './user.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    UserContext
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
        CourtesyClient,
        //OfficerClient,
        { provide: API_BASE_URL, useValue:  'http://devservices.apartmentapps.com' }
      ]
    };
  }
 }
