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
  @Input() actionLinks: FeedItemActionLink[];
  @Input() comments: CommentItem[];

  constructor() { }

  ngOnInit() {
  }

}
export class FeedItemActionLink {
    label: string;
    click: any;
    constructor(title: string, click: any) {
      this.label = title;
      this.click = click;
    }
    // (message: string): void;
}
