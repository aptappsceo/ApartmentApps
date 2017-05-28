import { Component, OnInit, Input } from '@angular/core';
import { UserBindingModel } from "app/aaservice-module/aaclient";

@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.css']
})
export class CommentItemComponent implements OnInit {

  @Input() commentItem: CommentItem;
  constructor() { }

  ngOnInit() {

  }

}
export class CommentItem {
  public time: string;
  public comment: string;
  public userInfo: UserBindingModel;
}
