
import {Component, Input, Output, EventEmitter} from "@angular/core";

@Component({
  templateUrl : 'section-placeholder.component.html',
  selector : 'section-placeholder-component'
})
export class SectionPlaceholder {
  @Input() public title : string;
  @Input() public actionTitle : string;
  @Input() public icon : string;

  @Output() public activate = new EventEmitter();

  public touch(){
    this.activate.emit();
  }

}
