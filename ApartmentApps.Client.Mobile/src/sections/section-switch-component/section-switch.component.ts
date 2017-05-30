
import {Component, Input, OnInit, Renderer, forwardRef} from '@angular/core';
import {ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';
import { NavController } from 'ionic-angular';
@Component({
  templateUrl : "section-switch.component.html",
  selector: 'section-switch-component',
  providers : [{
    provide: NG_VALUE_ACCESSOR,
    useExisting : forwardRef(()=> SectionSwitchComponent),
    multi : true
  }],
})
export class SectionSwitchComponent implements OnInit, ControlValueAccessor {


  constructor(public navCtrl: NavController, public renderer : Renderer) {
  }

  @Input() public sectionTitle : string;
  @Input() public sectionDescription : string;

  private propagateChange : any;
  private innerValue : string = '';

  public ngOnInit(): void {
  }

  public onBlur() : void {
  }

  get value(): any {
    return this.innerValue;
  };

  //set accessor including call the onchange callback
  set value(v: any) {
    if (v !== this.innerValue) {
      this.innerValue = v;
      if(this.propagateChange) {
        this.propagateChange(v);
      }
    }
  }

  writeValue(value: any): void {
    if (value !== this.innerValue) {
      this.innerValue = value;
    }
  }

  registerOnChange(fn: any): void {
    this.propagateChange = fn;
  }

  registerOnTouched(fn: any): void {
  }


}
