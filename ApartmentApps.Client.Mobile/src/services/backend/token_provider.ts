import {Injectable} from "@angular/core";
import {BehaviorSubject} from "rxjs";

@Injectable()
export class TokenProvider {

  public get accessToken(){
    return this.accessTokenProperty.value;
  };

  public set accessToken(token : string){
    this.accessTokenProperty.next(token);
  };

  public accessTokenProperty : BehaviorSubject<string> = new BehaviorSubject<string>(null);


}
