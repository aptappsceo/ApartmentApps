import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormComponent } from 'angular2-schema-form';
import { ModulesClient } from "app/aaservice-module/aaclient";
import { NotificationsService } from "angular2-notifications";

@Component({
  selector: 'app-settings-form',
  templateUrl: './settings-form.component.html',
  styleUrls: ['./settings-form.component.css']
})
export class SettingsFormComponent implements OnInit {
  propertyId: any;
  @Input() schema: any;
  @Input() moduleName: any;
  model: any = { };
  @Output() modelChanged: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild(FormComponent) form: FormComponent;
  id: string;
  constructor(public modules: ModulesClient, private notify: NotificationsService) {

  }

  ngOnInit() {
      this.modules.getConfig(this.moduleName).subscribe(x => {
        this.id = x.Id;
        this.propertyId = x.PropertyId;
        this.model = x;

        console.log(this.moduleName, x);
      });
  }

  save() {
    this.model.Id = this.id;
    this.model.PropertyId = this.propertyId;
    console.log("Saving", this.model);
    this.modules.saveConfig(this.moduleName, JSON.stringify(this.model)).subscribe( x => {
        this.notify.success('Settings saved successfully!');
     });
  }

}
