import {Component} from "@angular/core";
import {NavController, NavParams} from "ionic-angular";

@Component({
  templateUrl : 'fullscreen-image.page.html',
  selector : 'fullscreen-image-page-component'
})
export class FullscreenImagePage {

  public resource : string;

  constructor(public navCtrl: NavController, private navParams : NavParams) {
    this.resource = navParams.get('resource');
  }

  public closeClicked(){
    this.navCtrl.pop();
  }

}
