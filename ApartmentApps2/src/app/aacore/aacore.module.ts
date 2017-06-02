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
require('../../assets/select2.full.min.js');

export const corproutes = [
  { path: 'corporations', component: CorporationsPageComponent},
  { path: 'userprofile', component: UserProfileComponent },
];

@NgModule({
  imports: [
      CommonModule,
      FormsModule,
      RouterModule.forChild(corproutes),
      PaginationModule.forRoot(),
      Select2Module //, TagInputModule
  ],
  declarations: [
    CorporationsListComponent,
    CorporationsFormComponent,
    CorporationsPageComponent,
    UserProfileComponent,
    SearchPanelComponent,
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
