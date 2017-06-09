import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeedItemComponent } from './feeditem/feeditem.component';
import { TitleComponent } from './title/title.component';
import { CommentsComponent } from './comments/comments.component';
import { CommentItemComponent } from './comment-item/comment-item.component';
import { CarouselModule, ModalModule } from 'ngx-bootstrap';
import { ModalComponent } from './modal/modal.component';

@NgModule({
  imports: [
    CommonModule, CarouselModule.forRoot(), ModalModule.forRoot(),
  ],
  declarations: [FeedItemComponent, TitleComponent, CommentsComponent, CommentItemComponent, ModalComponent],
  exports: [FeedItemComponent, TitleComponent, ModalComponent]
})
export class WidgetsModule { }
