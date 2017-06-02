import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { ClientSearchFilterModel, FilterData } from "app/aaservice-module/aaclient";
import { LookupsClient } from '../../aaservice-module/aaclient';
import { Select2OptionData } from "ng2-select2";

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
  public items: Select2OptionData[];
  constructor(private lookupsClient: LookupsClient) { 


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
      console.log("LOOKING UP STUFF");
        this.lookupsClient
          .getLookups(this.model.dataSourceType, '')
          .subscribe(y=> {
            let result = y.result.map(x=>{ 
                return {
                  id: x.id,
                  text: x.title
                };
            });
            console.log("LOOKUP ITEMS", result);
            this.items = result;
          });
    }
 
                
  }

}
