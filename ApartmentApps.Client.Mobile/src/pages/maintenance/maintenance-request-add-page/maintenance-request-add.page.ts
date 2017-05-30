import {Component, OnInit} from "@angular/core";
import {LoadingService} from "../../../services/loading.service";
import {LookupPairModel, MaitenanceRequestModel} from "../../../services/backend/generated/backend.generated";
import {ToastService} from "../../../services/toast.service";
import {FormGroup, FormBuilder} from "@angular/forms";
import {Backend} from "../../../services/backend/backend-module";
import {NavControllerBase, NavController} from "ionic-angular";
import {MaintenanceRequestIndexPageComponent} from "../maintenance-request-index-page/maintenance-request-index.page";
import * as _ from 'lodash';
export const PetStatuses = [
  { text : 'No Pet', id : 'NoPet'},
  { text : 'Pet, Contained', id : 'PetContained'},
  { text : 'Pet, Free', id : 'PetFree'}
];

@Component({
  templateUrl : 'maintenance-request-add.page.html',
  selector : 'maintenance-request-add-page-component'
})
export class MaintenanceRequestAddPageComponent implements OnInit{

  public ready : boolean;

  public requestTypes : LookupPairModel[] = [];
  public units : LookupPairModel[] = [];

  public model : FormGroup;

  public petOptions : any;

  constructor(public backend : Backend,
              public loadingService : LoadingService,
              public navCtrl : NavController,
              public toastService : ToastService,
              public formBuilder : FormBuilder ) {
    this.petOptions = PetStatuses;
    this.model = this.formBuilder.group({
      'type' : [null],
      'unit' : [null],
      'petStatus' : [this.petOptions[0]],
      'comments' : [null],
      'photos' : [[]],
      'permissionToEnter' : [true],
      'isEmergency' : [false]
    });

  }

  public submit(){
    let value = this.model.value;

    this.loadingService.push("Submitting...").then(x=>{
      console.log(value);
      return this.backend.maintenance.submitRequest(new MaitenanceRequestModel({
        PermissionToEnter: value.permissionToEnter,
        PetStatus: value.petStatus.id,
        UnitId: value.unit.key,
        MaitenanceRequestTypeId: value.type.key,
        Comments: value.comments,
        Emergency: value.isEmergency,
        Images: _.map(value.photos as string[],str=>str.split(',')[1])
      })).toPromise();
    }).then(response=>{
      return this.loadingService.pop();
    }).then(_=>{
      this.navCtrl.setRoot(MaintenanceRequestIndexPageComponent);
    }).catch(_=>{
      this.loadingService.pop();
      this.toastService.show(_);
    })

  }

  public ngOnInit(): void {


    console.log(this.backend.lookups);

    this.loadingService.push('Loading request types...').then(_=>{
      return this.backend.maintenance.getMaitenanceRequestTypes().toPromise();
    }).then(requestTypes => {
      this.requestTypes = requestTypes;
      this.loadingService.replace('Loading units...');
      return this.backend.lookups.getUnits().toPromise();
    }).then(units => {
      this.units = units;
      this.ready = true;
      return this.loadingService.pop();
    }).catch(error=>{
      this.loadingService.pop();
      console.error(error);
      this.toastService.show('Something bad happened.')
    });


  }




}
