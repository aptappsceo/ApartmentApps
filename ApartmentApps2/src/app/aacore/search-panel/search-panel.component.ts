import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
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
  @Output() public updated: EventEmitter<FilterData> = new EventEmitter<FilterData>();
  constructor() { }
  valueChanged() {
    this.updated.emit(this.filterData);
    console.log(JSON.stringify({ value: this.value }));
  }
  get filterData(): FilterData {
    let filter = new FilterData();
    filter.filterId = this.model.id;
    filter.jsonValue = JSON.stringify({ value: this.value});
    return filter;
  }
  ngOnInit() {

  }

}
