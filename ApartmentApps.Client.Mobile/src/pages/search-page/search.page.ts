import { Component } from '@angular/core';
import {NavController, NavParams} from 'ionic-angular';
import * as _ from 'lodash';
import {LookupPairModel} from "../../services/backend/generated/backend.generated";

@Component({
  selector: 'search-page-component',
  templateUrl: 'search.page.html'
})
export class SearchPage {

  public query : string = '';

  public selectHandler : (item : LookupPairModel) => void;
  public options : LookupPairModel[];
  public filteredItems : LookupPairModel[];

  constructor(public navCtrl: NavController, private navParams : NavParams) {
    this.selectHandler = navParams.get('select');
    this.options = navParams.get('options') || [];
    this.filteredItems = this.options;
    this.query = '';
  }

  public onSearchbarInput(evt : any){
    var lwQuery = this.query.toLocaleLowerCase();
    this.filteredItems = _.chain(this.options)
      .filter(item => _.includes(item.value.toLowerCase(), lwQuery))
      .value();
  }

  public onSelect(item : LookupPairModel){
    if(this.selectHandler){
      this.selectHandler(item);
      this.navCtrl.pop();
    }
  }




}
