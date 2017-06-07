import { Component, OnInit } from '@angular/core';
import { PropertyClient, Query, Navigation } from 'app/aaservice-module/aaclient';

@Component({
  selector: 'app-properties-page',
  templateUrl: './properties-page.component.html',
  styleUrls: ['./properties-page.component.css']
})
export class PropertiesPageComponent implements OnInit {
  query: Query = new Query();

  constructor(private propertyClient: PropertyClient) {
    this.query.navigation = new Navigation();
    this.query.navigation.skip = 0;
    this.query.navigation.take = 20;

  }

  ngOnInit() {
    this.propertyClient
      .fetch(this.query)
      .subscribe(x => {
          console.log('properties', x);
       });
  }

}
