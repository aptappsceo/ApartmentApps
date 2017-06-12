import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { CourtesyClient, IncidentReportModel, IncidentReportModelIncidentReportTypeId } from "app/aaservice-module/aaclient";
import { NotificationsService } from "angular2-notifications";

@Component({
  selector: 'app-incident-report-form',
  templateUrl: './incident-report-form.component.html',
  styleUrls: ['./incident-report-form.component.css']
})
export class IncidentReportFormComponent implements OnInit {
//   string: string, search, tel, url, email, password, color, date, date-time, time, textarea, select, file, radio, richtext
// number: number, integer, range
// integer: integer, range
// boolean: boolean, checkbox
  @Output() public complete: EventEmitter<any> = new EventEmitter<any>();
  mySchema = {
    'properties': {
      'comments': {
        'type': 'string',
        'widget': 'textarea',
        'description': 'Describe the incident that has occured.'
      }
    },
    'required': ['comments']
  };
  myModel = {comments: 'fdsasdfasdfasdf'};

   constructor(private officerClient: CourtesyClient, private notificationService: NotificationsService) {

   }
   changed(stuff) {
     this.myModel = stuff;
   }
   Save() {
     let ir = new IncidentReportModel();
     ir.incidentReportTypeId = 1;
     ir.comments = this.myModel.comments;
    //console.log("model", this.myModel);
      this.officerClient.submitIncidentReport(ir).subscribe(x => {
          this.notificationService.success('Success!', 'Your incident report has been submitted.');
          this.complete.emit(null);
      });
   }
  ngOnInit() {

  }

}
