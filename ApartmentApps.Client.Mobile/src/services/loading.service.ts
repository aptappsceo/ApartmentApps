import {Injectable} from "@angular/core";
import {LoadingController, Loading} from "ionic-angular";

@Injectable()
export class LoadingService {

  constructor( public loadingCtrl : LoadingController) {

  }

  public currentLoading : Loading;
  public messageStack : string[] = [];

  public push(message : string) : Promise<any> {
    this.messageStack.push(message);
    return this.getLoading(message);
  }

  public replace(message : string) : Promise<any>{
    if(this.currentLoading){
      this.currentLoading.setContent(message);
    }
    return Promise.resolve();
  }

  public pop() : Promise<any> {
    this.messageStack.pop();
    if(this.messageStack.length > 0){
      return this.getLoading().then(s=>s.setContent(this.messageStack[this.messageStack.length-1]));
    } else {
      return this.disposeLoading();
    }
  }

  private getLoading(initContent : string = null) : Promise<Loading> {
    if(this.currentLoading){
      return Promise.resolve(this.currentLoading);
    } else {
      this.currentLoading = this.loadingCtrl.create({
        showBackdrop : true,
        delay : 300,
        dismissOnPageChange: false,
        content : initContent
      });
      return this.currentLoading.present().then(() => { return this.currentLoading });
    }
  }

  private disposeLoading() : Promise<any> {
    if(this.currentLoading){
      let c = this.currentLoading;
      this.currentLoading = undefined;
      return c.dismiss();
    } else {
      return Promise.resolve();
    }
  }

}
