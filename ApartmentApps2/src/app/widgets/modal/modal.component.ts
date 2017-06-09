import { Component, OnInit, ViewChild, Input, EventEmitter, Output } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {
  @ViewChild('childModal') public childModal: ModalDirective;
  @Input() public title: string;
  @Output() public ok: EventEmitter<ModalComponent> = new EventEmitter<ModalComponent>();
  @Input() public okText: string = 'Apply';
  constructor() { }

  public show(): void {
    this.childModal.show();
  }

  public hide(): void {
    this.childModal.hide();
  }
  ngOnInit() {
  }

}
