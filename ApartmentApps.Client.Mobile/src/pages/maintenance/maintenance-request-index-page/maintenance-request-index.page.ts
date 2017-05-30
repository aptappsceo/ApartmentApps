import { Component, OnInit } from '@angular/core';
import { LoadingService } from '../../../services/loading.service';
import {MaintenanceIndexBindingModel, Query} from '../../../services/backend/generated/backend.generated';
import { ToastService } from '../../../services/toast.service';
import {Backend} from "../../../services/backend/backend-module";
import * as _ from 'lodash';
import {NavController, MenuController} from "ionic-angular";
import {MaintenanceRequestDetailsPageComponent} from "../maintenance-request-details-page/maintenance-request-details.page";
import {queue} from "rxjs/scheduler/queue";
@Component({
  templateUrl : 'maintenance-request-index.page.html',
  selector : 'maintenance-request-index-page-component'
})
export class MaintenanceRequestIndexPageComponent implements OnInit{

  public model : MaintenanceIndexBindingModel[] = [];

  public query : Query = new Query({
    Navigation : {
      Skip : 0,
      Take : 5
    }, Search : {
        EngineId : "MaitenanceRequest"
    }
  });

  constructor(public backend : Backend,
              public navController : NavController,
              public loadingService : LoadingService,
              public menuCtrl : MenuController,
              public toastService : ToastService) {
  }

  public submit(model : any){

  }

  public ngOnInit(): void {
    console.log(this.query.search)
    this.update();

  }

  public openDetails(id : string) {
    this.navController.push(MaintenanceRequestDetailsPageComponent, {
      id : id
    });
  }

  public onSearchUpdate() {
    this.resetNavigation();
    this.update();
  }

  public update(): void {
    this.loadingService.push("Fetching requests").then(_=>{
      return this.backend.maintenance.fetch(this.query).toPromise();
    }).then(requests=>{
      this.model = requests.result;
      console.log(this.model);
    }).then(_=>{
      return this.loadingService.pop();
    }).catch(err=>{
      this.loadingService.pop();
      this.toastService.show("Unable to fetch requests");
      console.log(err);
    });
  }

  public resetNavigation() {
    this.query.navigation.skip = 0;
  }

  public fetchMore() : Promise<any> {

      this.query.navigation.skip += this.query.navigation.take;

      return this.backend.maintenance.fetch(this.query).toPromise().then(result=>{
        this.model = _.concat(this.model,result.result);
      });
  }

  public openSearch() {
      this.menuCtrl.toggle('right');
  }

  public fetchMoreItems(scrollContext : any){
      this.fetchMore().then(_=>{
        scrollContext.complete();
      }).catch(err=>{
        scrollContext.complete();
        this.toastService.show("Unable to fetch more fetch requests");
        console.log(err);
      })
  }

}
