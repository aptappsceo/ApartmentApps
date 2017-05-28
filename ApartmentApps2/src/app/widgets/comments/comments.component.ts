import { Component, OnInit, Input } from '@angular/core';
import { UserBindingModel } from "app/aaservice-module/aaclient";

@Component({
  selector: '[app-comments]',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {
  @Input() comments: Comment[];
  constructor() { }

  ngOnInit() {
    console.log("COMMENTS", this.comments);
  }

}
