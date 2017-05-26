import { Component, OnInit, Input } from '@angular/core';
import { UserInfoViewModel, UserBindingModel } from 'app/aaservice-module/aaclient';

@Component({
  selector: 'app-feeditem',
  templateUrl: './feeditem.component.html',
  styleUrls: ['./feeditem.component.scss']
})
export class FeedItemComponent implements OnInit {
  @Input() userInfo: UserBindingModel;
  @Input() imageUrl: string;
  @Input() tags: any;
  @Input() timeAgo: string;
  @Input() images: string[];
  @Input() bodyText: string;

  constructor() { }

  ngOnInit() {
  }

}
