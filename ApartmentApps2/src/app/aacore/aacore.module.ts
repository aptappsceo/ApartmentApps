import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CorporationsListComponent } from "./corporations/corporations-list/corporations-list.component";
import { CorporationsFormComponent } from "./corporations/corporations-form/corporations-form.component";
import { RouterModule } from '@angular/router';
import { CorporationsPageComponent } from './corporations/corporations-page/corporations-page.component';
import { UserProfileComponent } from './users/user-profile/user-profile.component';

export const corproutes = [
  { path: 'corporations', component: CorporationsPageComponent},
  { path: 'userprofile', component: UserProfileComponent },
];

@NgModule({
  imports: [
      CommonModule, RouterModule.forChild(corproutes)
  ],
  declarations: [
    CorporationsListComponent,
    CorporationsFormComponent,
    CorporationsPageComponent,
    UserProfileComponent
    ],
  providers: [

  ]
})
export class AACoreModule {
  static routes = corproutes;
}
