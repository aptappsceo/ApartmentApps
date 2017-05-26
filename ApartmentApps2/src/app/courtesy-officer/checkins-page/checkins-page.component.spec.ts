import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckinsPageComponent } from './checkins-page.component';

describe('CheckinsPageComponent', () => {
  let component: CheckinsPageComponent;
  let fixture: ComponentFixture<CheckinsPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckinsPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckinsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
