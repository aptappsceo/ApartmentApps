import { Component, OnInit, Input } from '@angular/core';
import { UserInfoViewModel, UserBindingModel } from 'app/aaservice-module/aaclient';
import { CommentItem } from "app/widgets/comment-item/comment-item.component";

@Component({
  selector: 'app-feeditem',
  templateUrl: './feeditem.component.html',
  styleUrls: ['./feeditem.component.scss']
})
export class FeedItemComponent implements OnInit {
  @Input() userInfo: UserBindingModel;
  @Input() images: string[];
  @Input() tags: any;
  @Input() timeAgo: string;
  @Input() bodyText: string;
  @Input() actionLinks: any[];
  @Input() comments: CommentItem[];

  constructor() { }

  ngOnInit() {
  }

}
export class FeedItemActionLink {

}
