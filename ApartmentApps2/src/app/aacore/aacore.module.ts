import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CorporationsListComponent } from "./corporations/corporations-list/corporations-list.component";
import { CorporationsFormComponent } from "./corporations/corporations-form/corporations-form.component";
import { RouterModule } from '@angular/router';
import { CorporationsPageComponent } from './corporations/corporations-page/corporations-page.component';
import { UserProfileComponent } from './users/user-profile/user-profile.component';
import { PaginationModule } from "ngx-bootstrap";
import { SearchPanelComponent } from 'app/aacore/search-panel/search-panel.component';
//import { TagInputModule } from 'ngx-tag-input';
import { FormsModule } from '@angular/forms';
import {Select2Module} from 'ng2-select2';
import { SearchPageComponent } from "app/aacore/search-page-component";
import { PropertiesFormComponent } from './properties/properties-form/properties-form.component';
import { PropertiesListComponent } from './properties/properties-list/properties-list.component';
import { PropertiesPageComponent } from './properties/properties-page/properties-page.component';
import { WidgetsModule } from "app/widgets/widgets.module";
import { BasePageComponent } from './base-page/base-page.component';
require('../../assets/select2.full.min.js');

export const corproutes = [
  { path: 'corporations', component: CorporationsPageComponent},
  { path: 'properties', component: PropertiesPageComponent},
  { path: 'userprofile', component: UserProfileComponent },
];

@NgModule({
  imports: [
      CommonModule,
      FormsModule,
      RouterModule.forChild(corproutes),
      PaginationModule.forRoot(),
      Select2Module,
      WidgetsModule,
  ],
  declarations: [
    CorporationsListComponent,
    CorporationsFormComponent,
    CorporationsPageComponent,
    UserProfileComponent,
    SearchPanelComponent,
    PropertiesFormComponent,
    PropertiesListComponent,
    PropertiesPageComponent,
    BasePageComponent,
    ],
    exports: [
      SearchPanelComponent,
      //SearchPageComponent
    ],
  providers: [

  ]
})
export class AACoreModule {
  static routes = corproutes;
}
