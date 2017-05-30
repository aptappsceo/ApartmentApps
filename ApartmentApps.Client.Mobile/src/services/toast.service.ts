

import {Injectable} from "@angular/core";
import {ToastController} from "ionic-angular";

@Injectable()
export class ToastService{

  constructor(public toastCtrl : ToastController){

  }

  public show(message : string, duration : number = 3000) {
    let toast = this.toastCtrl.create({
      message : message,
      duration : duration
    });
    toast.present();
  }

}
