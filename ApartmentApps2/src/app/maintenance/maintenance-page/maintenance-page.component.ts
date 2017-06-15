import { Component, OnInit } from '@angular/core';
import { MaitenanceClient, MaintenanceRequestViewModel } from 'app/aaservice-module/aaclient';

@Component({
  selector: 'app-maintenance-page',
  templateUrl: './maintenance-page.component.html',
  styleUrls: ['./maintenance-page.component.css']
})
export class MaintenancePageComponent implements OnInit {

  constructor(private client: MaitenanceClient) { }

  ngOnInit() {

  }
    getImages(incident: MaintenanceRequestViewModel): string[] {
    let result = [];
    for (let i = 0 ; i < incident.checkins.length; i++) {
      for (let x = 0; x < incident.checkins[i].photos.length; x++ ) {
        result.push(incident.checkins[i].photos[i].url);
      }
    }
    return result;
  }
  fetch(evt: any) {
    this.client.fetch(evt.query).subscribe(evt.callback);
  }
}
