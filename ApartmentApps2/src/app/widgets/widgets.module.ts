import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeedItemComponent } from './feeditem/feeditem.component';
import { TitleComponent } from './title/title.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [FeedItemComponent, TitleComponent],
  exports: [FeedItemComponent, TitleComponent]
})
export class WidgetsModule { }
