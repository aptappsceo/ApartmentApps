import { Component, OnInit } from '@angular/core';
import { ModulesClient } from "app/aaservice-module/aaclient";

@Component({
  selector: 'app-settings-page',
  templateUrl: './settings-page.component.html',
  styleUrls: ['./settings-page.component.css']
})
export class SettingsPageComponent implements OnInit {
  public schemas: any[];
  constructor(private modules: ModulesClient) {

  }

  ngOnInit() {
    this.modules.moduleSchemas().subscribe(_ => {
      this.schemas = _;
      console.log("all schemas", _);
    });
  }

}
