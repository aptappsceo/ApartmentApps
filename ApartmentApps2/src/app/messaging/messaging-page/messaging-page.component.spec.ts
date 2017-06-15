import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagingPageComponent } from './messaging-page.component';

describe('MessagingPageComponent', () => {
  let component: MessagingPageComponent;
  let fixture: ComponentFixture<MessagingPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MessagingPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessagingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});