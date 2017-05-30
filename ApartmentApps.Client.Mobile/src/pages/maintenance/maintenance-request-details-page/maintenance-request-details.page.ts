import {Component, OnInit, ViewChild} from '@angular/core';
import { LoadingService } from '../../../services/loading.service';
import { ToastService }  from '../../../services/toast.service';
import { FormBuilder } from '@angular/forms';
import { Backend } from '../../../services/backend/backend-module';
import {NavParams, NavController, ModalController} from 'ionic-angular';
import {
  MaintenanceBindingModel,
  MaintenanceCheckinBindingModel
} from '../../../services/backend/generated/backend.generated';
import * as _ from 'lodash';
import {CheckinPageComponent} from "../checkin-page/checkin.page";
import {FullscreenImagePage} from "../../fullscreen-image-page/fullscreen-image.page";
import * as moment from 'moment';
@Component({
  templateUrl : 'maintenance-request-details.page.html',
  selector : 'maintenance-request-details-page-component'
})
export class MaintenanceRequestDetailsPageComponent implements OnInit{

  public modelId;
  public model : MaintenanceBindingModel;
  public history : MaintenanceCheckinBindingModel[];

  public scheduleDate = moment().toISOString();

  @ViewChild('scheduler') scheduler;
  private checkins = [];
  constructor(public backend : Backend,
              public loadingService : LoadingService,
              public toastService : ToastService,
              public navController : NavController,
              public modalCtrl : ModalController,
              public navParams : NavParams,
              public formBuilder : FormBuilder ) {

    this.modelId = navParams.get('id');
  }

  public update() {

    if(!this.modelId) {
      return this.navController.pop(); // no data, leave
    }

    Promise.resolve().then(_=>{
      return this.loadingService.push("Fetching request data...");
    }).then(_=>{
      return this.backend.maintenance.get(this.modelId).toPromise();
    }).then(request=>{
      this.model = request;
     // this.checkins = this.model.checkins ? _.rest(this.model.checkins,0) : [];
      this.history = _.chain(this.model.checkins).slice(1).value();
    }).then(_=>{
      this.loadingService.pop();
    }).catch(_=>{
      this.loadingService.pop();
      this.navController.pop();
      this.toastService.show("Could not load request data.");
      console.error(_);
    });

  }

  public start() {
    if(!this.model || !this.model.canStart) return;
    this.requestChecking((comments,qr,coords,photos)=>{
      this.loadingService.push('Starting...').then(_=>{
        return this.backend.maintenance.startRequest(this.modelId,comments,photos).toPromise();
      }).then(_=>{
        return this.loadingService.pop();
      }).then(_=>{
        return this.update();
      })
    });
  }

  public schedule() {
    if(!this.model || !this.model.canSchedule || !this.scheduler) return;
    this.scheduler.open();
    console.log(this.scheduleDate);
  }

  public requestChecking(action : (comment: string, qr: string, geo : Coordinates, photos : string[]) => void){
    this.navController.push(CheckinPageComponent, {
      title : 'Start Request',
      actionTitle : 'Start',
      action : action
    });
  }

  public scheduled(evt : any) {
    this.loadingService.push('Scheduling...').then(_=>{
      return this.backend.maintenance.scheduleRequest(this.modelId,new Date(this.scheduleDate)).toPromise();
    }).then(_=>{
      return this.loadingService.pop();
    }).then(_=>{
      return this.update();
    })
  }

  public scheduleCancelled(evt : any) {
  }

  public viewResource(url : string){
    let modal = this.modalCtrl.create(FullscreenImagePage, {
      resource: url
    });
    modal.present();
  }

  public ngOnInit(): void {
      this.update();
  }


}
