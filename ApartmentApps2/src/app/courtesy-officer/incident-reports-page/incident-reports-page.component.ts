import { Component, OnInit } from '@angular/core';
import { CourtesyClient, IncidentIndexBindingModel } from 'app/aaservice-module/aaclient';

@Component({
  selector: 'app-incident-reports-page',
  templateUrl: './incident-reports-page.component.html',
  styleUrls: ['./incident-reports-page.component.css']
})
export class IncidentReportsPageComponent implements OnInit {
  incidents: IncidentIndexBindingModel[];

  constructor( private officerClient: CourtesyClient ) { }

  ngOnInit() {
    this.officerClient.listRequests().subscribe( x => {
        this.incidents = x;
        console.log(this.incidents);
    });
  }

}
