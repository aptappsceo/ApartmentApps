import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CorporationsListComponent } from "./corporations/corporations-list/corporations-list.component";
import { CorporationsFormComponent } from "./corporations/corporations-form/corporations-form.component";
import { RouterModule } from '@angular/router';
import { CorporationsPageComponent } from './corporations/corporations-page/corporations-page.component';

export const corproutes = [
  { path: '', component: CorporationsPageComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [
      CommonModule, RouterModule.forChild(corproutes)
  ],
  declarations: [CorporationsListComponent, CorporationsFormComponent, CorporationsPageComponent],
  providers: [

  ]
})
export class AACoreModule {
  static routes = corproutes;
}
