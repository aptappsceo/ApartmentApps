import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeedItemComponent } from './feeditem/feeditem.component';
import { TitleComponent } from './title/title.component';
import { CommentsComponent } from './comments/comments.component';
import { CommentItemComponent } from './comment-item/comment-item.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [FeedItemComponent, TitleComponent, CommentsComponent, CommentItemComponent],
  exports: [FeedItemComponent, TitleComponent]
})
export class WidgetsModule { }
