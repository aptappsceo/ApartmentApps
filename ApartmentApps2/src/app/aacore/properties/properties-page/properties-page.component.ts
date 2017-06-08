import { Component, OnInit, ViewChildren, QueryList } from '@angular/core';
import { PropertyClient, Query, Navigation, QueryResultOfPropertyIndexBindingModel, PropertyIndexBindingModel } from 'app/aaservice-module/aaclient';
import { SearchPanelComponent } from "app/aacore/search-panel/search-panel.component";

@Component({
  selector: 'app-properties-page',
  templateUrl: './properties-page.component.html',
  styleUrls: ['./properties-page.component.css']
})
export class PropertiesPageComponent implements OnInit {
  result: QueryResultOfPropertyIndexBindingModel;
  query: Query = new Query();
  @ViewChildren(SearchPanelComponent) searchComponents: QueryList<SearchPanelComponent>;

  constructor(private propertyClient: PropertyClient) {
    this.query.navigation = new Navigation();
    this.query.navigation.skip = 0;
    this.query.navigation.take = 10;

  }
onChangeTable(config, $event) {
  this.query.navigation.skip = ($event.page - 1) * this.query.navigation.take;
  console.log(config, $event, this.query.navigation);
  this.reloadData();
}
filtersUpdate() {
  this.reloadData();
}
  reloadData() {
    // let items = this.searchComponents
    //   .filter((x, i) => x.value != null && x.active)
    //   .map(x => x.filterData);
    // console.log('ITEMS', items);
    // this.query.search.filters = items;
    this.propertyClient
      .fetch(this.query)
      .subscribe(x => {
          this.result = x;
          console.log('properties', x);
       });
  }
  ngOnInit() {
   this.reloadData();
  }
  setActive(item: PropertyIndexBindingModel) {
    this.propertyClient.activate(item.id).subscribe(() => {
        //Messenger().post("Thanks for checking out Messenger!");
        //window.location.href = window.location.href;
    });
  }
}
