import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeedItemComponent } from './feeditem/feeditem.component';
import { TitleComponent } from './title/title.component';
import { CommentsComponent } from './comments/comments.component';
import { CommentItemComponent } from './comment-item/comment-item.component';
import { CarouselModule } from 'ngx-bootstrap';

@NgModule({
  imports: [
    CommonModule, CarouselModule.forRoot()
  ],
  declarations: [FeedItemComponent, TitleComponent, CommentsComponent, CommentItemComponent],
  exports: [FeedItemComponent, TitleComponent]
})
export class WidgetsModule { }
