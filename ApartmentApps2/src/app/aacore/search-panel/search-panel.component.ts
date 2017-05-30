import { Component, OnInit, Input } from '@angular/core';
import { ClientSearchFilterModel } from "app/aaservice-module/aaclient";

@Component({
  selector: 'app-search-panel',
  templateUrl: './search-panel.component.html',
  styleUrls: ['./search-panel.component.css']
})
export class SearchPanelComponent implements OnInit {
  @Input() public model: ClientSearchFilterModel;
  constructor() { }

  ngOnInit() {

  }

}
