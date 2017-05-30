import {Injectable} from "@angular/core";
import {BehaviorSubject} from "rxjs";

@Injectable()
export class AppConfig {

  public authEndpoint : string;

  public get endpoint() {
    return this.endpointProperty.value;
  }

  public set endpoint(url : string) {
    this.endpointProperty.next(url);
  }

  public endpointProperty : BehaviorSubject<string> = new BehaviorSubject(null);

  constructor(){
    //this.endpoint = 'http://apartmentappsapiservice.azurewebsites.net';
    //this.endpoint = 'http://devservices.apartmentapps.com';
    //this.endpoint = 'http://192.168.1.182:54686';
    this.endpoint = 'http://localhost:54686';
    this.authEndpoint = this.endpoint+'/Token';
  }



}

