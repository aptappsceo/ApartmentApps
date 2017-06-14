import { Component, OnInit, Input, ViewChildren, QueryList, EventEmitter, Output } from '@angular/core';
import { SearchEnginesClient, Query, ClientSearchModel, Search, Navigation } from "app/aaservice-module/aaclient";
import { SearchPanelComponent } from "app/aacore/search-panel/search-panel.component";

@Component({
  selector: 'app-base-page',
  templateUrl: './base-page.component.html',
  styleUrls: ['./base-page.component.css']
})
export class BasePageComponent implements OnInit {
   totalRecords: any;
   @Input() searchEngineId: string;
   query: Query = new Query();
   items: any[];
   page: Number = 1;
   searchModel: ClientSearchModel;
   @Output() fetchData: EventEmitter<any> = new EventEmitter<any>();
   @ViewChildren(SearchPanelComponent) searchComponents: QueryList<SearchPanelComponent>;

   constructor(private searchEngine: SearchEnginesClient) {
      this.query.navigation = new Navigation();
      this.query.navigation.skip = 0;
      this.query.navigation.take = 5;

   }
    onChangeTable(config, $event) {
      this.query.navigation.skip = ($event.page - 1) * this.query.navigation.take;
      console.log(config, $event, this.query.navigation);
      this.reloadData();
    }

    // fetchData(callback: any): void {

    // }

    reloadData() {
      if (this.searchEngineId != null) {
        let items = this.searchComponents
          .filter((x, i) => x.value != null && x.active)
          .map(x => x.filterData);
        this.query.search.filters = items;
      }


    this.fetchData.emit( {
            query: this.query,
            callback:  x => {
                this.items = x.result;
                this.totalRecords = x.total;
                console.log('ITEMS', this.items);
              }
          }
        );
  }
  ngOnInit() {
    if (this.searchEngineId != null) {
      this.searchEngine.getSearchModel(this.searchEngineId)
            .subscribe(x => {
                this.searchModel = x.model;
                this.query.search = new Search();
                this.query.search.engineId = this.searchEngineId;
               });
    }
    this.reloadData();
  }

}
