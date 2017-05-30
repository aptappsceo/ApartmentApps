import { Component, OnInit, Input } from '@angular/core';
import { ClientSearchFilterModel, FilterData } from "app/aaservice-module/aaclient";

@Component({
  selector: 'app-search-panel',
  templateUrl: './search-panel.component.html',
  styleUrls: ['./search-panel.component.css']
})
export class SearchPanelComponent implements OnInit {
  @Input() public model: ClientSearchFilterModel;
  public value: any;
  @Input() public active: boolean;
  constructor() { }
  valueChanged() {
    console.log(JSON.stringify({ value: this.value }));
  }
  get filterData(): FilterData {
    let filter = new FilterData();
    filter.filterId = this.model.id;
    filter.jsonValue = JSON.stringify(this.value);
    return filter;
  }
  ngOnInit() {

  }

}
