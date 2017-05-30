
import {Component, Input, OnInit, ViewChild, Renderer, forwardRef} from '@angular/core';
import {ControlValueAccessor, NG_VALUE_ACCESSOR} from '@angular/forms';
import { NavController } from 'ionic-angular';
import { Keyboard } from 'ionic-native';
@Component({
  templateUrl : "section-textarea.component.html",
  selector: 'section-textarea-component',
  providers : [{
    provide: NG_VALUE_ACCESSOR,
    useExisting : forwardRef(()=> SectionTextareaComponent),
    multi : true
  }],
})
export class SectionTextareaComponent implements OnInit, ControlValueAccessor {


  constructor(public navCtrl: NavController, public renderer : Renderer) {
  }

  @Input() public startActive : boolean = false;
  @Input() public placeholderTitle : string;
  @Input() public placeholderActionTitle : string;
  @Input() public placeholderIcon : string;
  @Input() public sectionTitle : string;

  @ViewChild('textArea') public textArea;

  public isActive : boolean;

  private propagateChange : any;
  private innerValue : string = '';

  public ngOnInit(): void {
    this.isActive = this.startActive;
  }

  public onActivate() : void {
    this.isActive = true;

    setTimeout(()=>{
      this.textArea.setFocus();
      Keyboard.show();
    });

  }

  public onBlur() : void {
    if(!this.value) {
      this.isActive = false;
    }
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
