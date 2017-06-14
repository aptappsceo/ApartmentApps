import { Component, OnInit } from '@angular/core';
import { MaitenanceClient } from 'app/aaservice-module/aaclient';

@Component({
  selector: 'app-maintenance-page',
  templateUrl: './maintenance-page.component.html',
  styleUrls: ['./maintenance-page.component.css']
})
export class MaintenancePageComponent implements OnInit {

  constructor(private client: MaitenanceClient) { }

  ngOnInit() {

  }
  fetch(evt: any) {
    this.client.fetch(evt.query).subscribe(evt.callback);
  }
}
