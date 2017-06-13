import { Component, OnInit } from '@angular/core';
import { StringWidget } from 'angular2-schema-form';
import { LookupsClient } from "app/aaservice-module/aaclient";

@Component({
  selector: 'app-sf-remote-select',
  templateUrl: './sf-remote-select.component.html',
  styleUrls: ['./sf-remote-select.component.css']
})
export class SfRemoteSelectComponent extends StringWidget implements OnInit {
  items: {
    id: string;
    text: string;
  }[];

  constructor(private lookups: LookupsClient) {
    super();
   }

  ngOnInit() {
    this.lookups.getLookups(this.schema.remote, '') .subscribe(y=> {
            let result = y.result.map(x => {
                return {
                  id: x.id,
                  text: x.title
                };
            });
            this.items = result;
          });
  }

}
