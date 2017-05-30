import { Component } from '@angular/core';
import {NavController, NavParams} from 'ionic-angular';
import * as _ from 'lodash';
import {
  LookupPairModel, QueryResultOfLookupBindingModel,
  LookupBindingModel
} from "../../services/backend/generated/backend.generated";
import {Observable} from "rxjs";

@Component({
  selector: 'lookup-page-component',
  templateUrl: 'lookup.page.html'
})
export class LookupPage {

  public query : string = '';

  public selectHandler : (item : LookupBindingModel | LookupBindingModel[]) => void;
  public options : LookupBindingModel[];
  public filteredItems : LookupBindingModel[];
  public value : LookupBindingModel | LookupBindingModel[];
  public remote : (query:string) => Observable<QueryResultOfLookupBindingModel>;
  public allowMultiple: boolean;

  constructor(public navCtrl: NavController, private navParams : NavParams) {

    let val = navParams.get('value');
    this.selectHandler = navParams.get('select');
    this.options = navParams.get('options') || [];
    this.remote = navParams.get('remote');
    this.filteredItems = this.options;
    this.query = '';
    if(val && val instanceof Array){
      this.value = _.clone(val);
      this.allowMultiple = true;

    } else {
      this.value = val;
      this.allowMultiple = false;

    }


    if(this.value && this.value instanceof Array) {
      _.forEach(this.value,item=>{
          item.selected = true;
      });
    }

  }

  public onSearchbarInput(evt : any){
    let lwQuery = this.query.toLocaleLowerCase();
    if(this.remote){
      this.remote(lwQuery).toPromise().then(response =>{
        if(response .result.length == 0){
          this.filteredItems = [];
        } else {
          this.filteredItems = _.map(response.result, item=> {
            item.selected = _.some(this.value,i2=> i2.id === item.id)
            return item;
          });
        }
      })}
    else {
      this.filteredItems = _.chain(this.options)
        .filter(item => _.includes(this.searchString(item),lwQuery))
        .map(item=> {
          item.selected = _.some(this.value,i2=> i2.id === item.id)
          return item;
        }).value();

    }

  }

  public onSelect(item : LookupBindingModel){

    if(!(this.value instanceof Array)){ // working with single value
      this.navCtrl.pop().then(_=>{
        this.selectHandler(item);
      });
    } else { //working with array
      if(_.some(this.value, i=>i.id === item.id)){
        item.selected = false;

        this.value = _.filter(this.value,anotherItem => anotherItem.id != item.id);
      } else {
        item.selected = true;
        this.value = _.concat(this.value,[item]);
      }
      console.log(this.value);
    }

  }

  public closeClicked() {
    this.navCtrl.pop().then(_=>{
      if(this.value instanceof Array) //if working with multiple values, save the result
      this.selectHandler(this.value);
    });
  }

  private searchString(item : LookupBindingModel){
    var res = '';
    if(item.title) res+=item.title.toLocaleLowerCase();
    if(item.textPrimary) res+=item.textPrimary.toLocaleLowerCase();
    if(item.textSecondary) res+=item.textSecondary.toLocaleLowerCase();
    return res;
  }


}
