
import {Component, Input, OnInit, forwardRef} from "@angular/core";
import {Observable} from "rxjs";
import { SearchPage } from "../../pages/search-page/search.page";
import {ControlValueAccessor, NG_VALUE_ACCESSOR} from "@angular/forms";
import {NavController} from "ionic-angular";
import {LookupPairModel} from "../../services/backend/generated/backend.generated";

@Component({
  templateUrl : "section-select.component.html",
  selector: 'section-select-component',
  providers : [{
    provide: NG_VALUE_ACCESSOR,
    useExisting : forwardRef(()=> SectionSelectComponent),
    multi : true
  }],
})
export class SectionSelectComponent implements OnInit, ControlValueAccessor {


  constructor(public navCtrl: NavController) {
  }

  @Input() public startActive : boolean = false;
  @Input() public placeholderTitle : string;
  @Input() public placeholderActionTitle : string;
  @Input() public placeholderIcon : string;

  @Input() public sectionTitle : string;
  @Input() public buttonTitle : string;

  @Input() public remoteOptions : (query:string)=>Observable<LookupPairModel[]>;
  @Input() public localOptions : LookupPairModel[];

  public selectedItem : LookupPairModel | LookupPairModel;

  public isActive : boolean;

  private propagateChange : any;

  public ngOnInit(): void {
    this.isActive = this.startActive;
  }

  public onActivate() : void {
    this.openLookupPage();
  }

  public openLookupPage(){
    this.navCtrl.push(SearchPage, {
      options : this.localOptions,
      select : (item : LookupPairModel) => this.finishSelect(item)
    })
  }

  public finishSelect(item : LookupPairModel){
    if(item) {
      this.isActive = true;
      this.selectedItem = item;
      if (this.propagateChange) {
        this.propagateChange(item);
      }
    }
  }

  writeValue(obj: any): void {
    this.selectedItem = obj;
  }

  registerOnChange(fn: any): void {
    this.propagateChange = fn;
  }

  registerOnTouched(fn: any): void {
  }


}
