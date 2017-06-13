import { Component, OnInit } from '@angular/core';
import { CorporationClient, CorporationIndexBindingModel } from "app/aaservice-module/aaclient";

@Component({
  selector: 'app-corporations-page',
  templateUrl: './corporations-page.component.html',
  styleUrls: ['./corporations-page.component.css']
})
export class CorporationsPageComponent implements OnInit {
  items: CorporationIndexBindingModel[];

  constructor(private client: CorporationClient) { }

  ngOnInit() {

  }
  fetch(evt: any) {
    this.client.fetch(evt.query).subscribe(evt.callback);
  }
}
