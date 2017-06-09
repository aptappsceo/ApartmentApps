import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { ClientSearchFilterModel, FilterData } from "app/aaservice-module/aaclient";
import { LookupsClient, LookupBindingModel } from '../../aaservice-module/aaclient';
import { Select2OptionData } from "ng2-select2";

@Component({
  selector: 'app-search-panel',
  templateUrl: './search-panel.component.html',
  styleUrls: ['./search-panel.component.css']
})
export class SearchPanelComponent implements OnInit {
  @Input() public model: ClientSearchFilterModel;
  @Input() public value: any;
   public get active(): boolean {
     return this.value != null && this.value.length > 0;
   }
  @Output() public updated: EventEmitter<FilterData> = new EventEmitter<FilterData>();
  public items: Select2OptionData[];
  constructor(private lookupsClient: LookupsClient) {


  }
  checkboxListItemChanged($event, item: LookupBindingModel) {
    console.log($event);
    console.log(item);
    if (this.value == null)
      this.value = [];

    let index = this.value.indexOf(item.id);
    if (index > -1) {
      this.value.splice(index, 1);
    } else {
      this.value.push(item.id);
    }
    this.valueChanged();
  }
  changed(e) {
    console.log(e);
    this.value = e.value;
    this.valueChanged();
  }
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

    if (this.model.dataSourceType != null) {
        this.lookupsClient
          .getLookups(this.model.dataSourceType, '')
          .subscribe(y=> {
            let result = y.result.map(x=>{
                return {
                  id: x.id,
                  text: x.title
                };
            });
            this.items = result;
          });
    }


  }

}
