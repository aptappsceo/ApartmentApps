import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { AppComponent } from './app.component';
import { AuthClient } from '../services/backend/auth.client';
import { IdentityService } from '../services/identity.service';
import { LoginPageComponent } from '../pages/login-page/login.page';
import { BlankPageComponent } from '../pages/blank-page/blank.page';
import { LoadingService } from '../services/loading.service';
import { ToastService } from '../services/toast.service';
import { AppConfig } from "../appconfig";
import { BackendModule, Backend } from "../services/backend/backend-module";
import { SearchPage } from '../pages/search-page/search.page';
import { SectionSelectComponent } from '../sections/section-select-component/section-select.component';
import { SectionPlaceholder } from '../sections/section-placeholder.component';
import { MaintenanceRequestAddPageComponent } from '../pages/maintenance/maintenance-request-add-page/maintenance-request-add.page';
import { SectionSegmentSelectComponent } from '../sections/section-segment-select-component/section-segment-select.component';
import { SectionTextareaComponent } from '../sections/section-textarea-component/section-textarea.component';
import { SectionSwitchComponent } from '../sections/section-switch-component/section-switch.component';
import { SectionPhotosComponent } from '../sections/section-photos-component/section-photos.component';
import { GroupsPipe } from '../pipes/groups.pipe';
import { FullscreenImagePage } from '../pages/fullscreen-image-page/fullscreen-image.page';
import { MaintenanceRequestIndexPageComponent } from '../pages/maintenance/maintenance-request-index-page/maintenance-request-index.page';
import { MaintenanceRequestDetailsPageComponent } from '../pages/maintenance/maintenance-request-details-page/maintenance-request-details.page';
import {PetStatusPipe} from "../pipes/pet-status.pipe";
import {LookupPage} from "../pages/lookup-page/lookup.page";
import {SearchPanelComponent} from "../components/search-panel/search-panel.component";
import {SearchSelectFilter} from "../components/search-panel/search-select-filter.component";
import {CheckinPageComponent} from "../pages/maintenance/checkin-page/checkin.page";

@NgModule({
  declarations: [
    SearchPanelComponent,
    SearchSelectFilter,
    AppComponent,
    LoginPageComponent,
    BlankPageComponent,
    SearchPage,
    FullscreenImagePage,
    SectionSelectComponent,
    SectionPlaceholder,
    SectionTextareaComponent,
    SectionSwitchComponent,
    SectionSegmentSelectComponent,
    SectionPhotosComponent,
    MaintenanceRequestAddPageComponent,
    MaintenanceRequestIndexPageComponent,
    MaintenanceRequestDetailsPageComponent,
    GroupsPipe,
    PetStatusPipe,
    LookupPage,
    CheckinPageComponent
  ],
  imports: [
    IonicModule.forRoot(AppComponent),
    BackendModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    AppComponent,
    LoginPageComponent,
    BlankPageComponent,
    SearchPage,
    FullscreenImagePage,
    MaintenanceRequestAddPageComponent,
    MaintenanceRequestIndexPageComponent,
    MaintenanceRequestDetailsPageComponent,
    LookupPage,
    CheckinPageComponent
  ],
  providers: [
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    AppConfig,
    AuthClient,
    Backend,
    IdentityService,
    LoadingService,
    ToastService
  ]
})
export class AppModule {}
