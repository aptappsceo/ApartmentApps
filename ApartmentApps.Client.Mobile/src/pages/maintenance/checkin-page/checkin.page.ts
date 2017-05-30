import {Component, OnInit} from "@angular/core";
import {LoadingService} from "../../../services/loading.service";
import {LookupPairModel} from "../../../services/backend/generated/backend.generated";
import {ToastService} from "../../../services/toast.service";
import {FormGroup, FormBuilder} from "@angular/forms";
import {Backend} from "../../../services/backend/backend-module";
import {BarcodeScanner, Geolocation} from "ionic-native";
import {NavController, NavParams} from "ionic-angular";
import * as _ from 'lodash';
@Component({
  templateUrl : 'checkin.page.html',
  selector : 'checkin-page-component'
})
export class CheckinPageComponent implements OnInit{

  public model : FormGroup;
  public action : (comment: string, qr: string, geo : Coordinates, photos : string[]) => void;
  public actionTitle : string;
  public title: string;

  constructor(public backend : Backend,
              public loadingService : LoadingService,
              public toastService : ToastService,
              public navCtrl : NavController,
              public navParams : NavParams,
              public formBuilder : FormBuilder ) {

    this.action = navParams.get('action');
    this.actionTitle = navParams.get('actionTitle');
    this.title = navParams.get('title');

    this.model = this.formBuilder.group({
      'comments' : [""],
      'photos' : [[]],
      'coords' : null,
      'barcode' : null
    });

  }

  public submit(){
    this.scanBarcode().then(_=>{
        return this.getGeolocation();
      }).then(_=>{
        return this.navCtrl.pop();
      }).then(x=>{
        var val = this.model.value;
        return this.action(val.comments,val.barcode,val.coords,_.map(val.photos as string[],str=>str.split(',')[1]));
      }).catch(_=>{
        this.toastService.show(_);
        console.error(_);
      });
  }

  private scanBarcode(): Promise<string> {

      return BarcodeScanner.scan().then((barcodeData) => {
        if (barcodeData) {
          if (barcodeData.cancelled) {
            return Promise.reject('Cancelled');
          } else {
            this.model.controls['barcode'].setValue(barcodeData.text);
          }
        }
      });

  }

  private getGeolocation(): Promise<string> {

    return Geolocation.getCurrentPosition({
      enableHighAccuracy: true,
      maximumAge: 0,
      timeout: 5000
    }).then(location => {
      this.model.controls['coords'].setValue(location.coords)
    });

  }

  public ngOnInit(): void {

  }




}
