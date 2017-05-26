import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IncidentReportFormComponent } from './incident-report-form/incident-report-form.component';
import { IncidentReportsListComponent }
  from './incident-reports-list/incident-reports-list.component';
import { IncidentReportsPageComponent }
  from './incident-reports-page/incident-reports-page.component';
import { CheckinsPageComponent } from './checkins-page/checkins-page.component';
import { CheckinsListComponent } from './checkins-list/checkins-list.component';
import { RouterModule } from "@angular/router";
import { WidgetsModule } from '../widgets/widgets.module';
export const routes = [
  { path: 'checkins', component: CheckinsPageComponent },
  { path: 'incidents', component: IncidentReportsPageComponent },
];
@NgModule({
  imports: [
    CommonModule, RouterModule.forChild(routes), WidgetsModule
  ],
  declarations: [
    IncidentReportFormComponent,
    IncidentReportsListComponent,
    IncidentReportsPageComponent,
    CheckinsPageComponent,
    CheckinsListComponent
    ]
})
export class CourtesyOfficerModule {
  static routes = routes;
 }
