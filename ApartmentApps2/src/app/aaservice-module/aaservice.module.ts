import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountClient, MaitenanceClient, MessagingClient, API_BASE_URL, CourtesyClient, SearchEnginesClient, LookupsClient, PropertyClient } from './aaclient';
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

  static forRoot(): ModuleWithProviders {
    return {
      ngModule: AAServiceModule,
      providers: [
        { provide: API_BASE_URL, useValue:  'http://devservices.localhost.com' },
        AuthClient,
        UserContext,
        AccountClient,
        UserService,
        CourtesyClient,
        SearchEnginesClient,
        LookupsClient,
        PropertyClient
        //OfficerClient,

      ]
    };
  }
 }
