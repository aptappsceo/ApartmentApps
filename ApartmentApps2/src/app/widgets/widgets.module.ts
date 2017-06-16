import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeedItemComponent } from './feeditem/feeditem.component';
import { TitleComponent } from './title/title.component';
import { CommentsComponent } from './comments/comments.component';
import { CommentItemComponent } from './comment-item/comment-item.component';
import { CarouselModule, ModalModule } from 'ngx-bootstrap';
import { ModalComponent } from './modal/modal.component';
import { RouterModule } from '@angular/router';
import { ActionUpdateFormComponent } from './action-update-form/action-update-form.component';
import { SchemaFormModule } from 'angular2-schema-form';

@NgModule({
  imports: [
    CommonModule, RouterModule, CarouselModule.forRoot(), ModalModule.forRoot(), SchemaFormModule
  ],
  declarations: [FeedItemComponent, TitleComponent, CommentsComponent, CommentItemComponent, ModalComponent, ActionUpdateFormComponent],
  exports: [FeedItemComponent, TitleComponent, ModalComponent, ActionUpdateFormComponent]
})
export class WidgetsModule { }
