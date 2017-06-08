import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IncidentReportFormComponent } from './incident-report-form/incident-report-form.component';
import { IncidentReportsListComponent }
  from './incident-reports-list/incident-reports-list.component';
import { IncidentReportsPageComponent }
  from './incident-reports-page/incident-reports-page.component';
import { CheckinsPageComponent } from './checkins-page/checkins-page.component';
import { CheckinsListComponent } from './checkins-list/checkins-list.component';
import { RouterModule } from '@angular/router';
import { WidgetsModule } from '../widgets/widgets.module';
import { PaginationModule, ModalModule, AccordionModule } from 'ngx-bootstrap';
import { FormsModule } from '@angular/forms';
import { AACoreModule } from 'app/aacore/aacore.module';
import { Select2Module } from 'ng2-select2';
import { SchemaFormModule, WidgetRegistry, DefaultWidgetRegistry } from 'angular2-schema-form';
import { IncidentDetailsPageComponent } from './incident-details-page/incident-details-page.component';

export const routes = [
  { path: 'checkins', component: CheckinsPageComponent },
  { path: 'incidents', component: IncidentReportsPageComponent },
  { path: 'incident/:id', component: IncidentReportsPageComponent },
];
@NgModule({
  imports: [
    CommonModule, RouterModule.forChild(routes), FormsModule,
    SchemaFormModule,
     PaginationModule.forRoot(), WidgetsModule, AACoreModule, Select2Module, ModalModule.forRoot(),
      AccordionModule.forRoot()
  ],
  declarations: [

    IncidentReportFormComponent,
    IncidentReportsListComponent,
    IncidentReportsPageComponent,
    CheckinsPageComponent,
    CheckinsListComponent,
    IncidentDetailsPageComponent
    ]
})
export class CourtesyOfficerModule {
  static routes = routes;
 }
