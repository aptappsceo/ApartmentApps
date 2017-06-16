import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionUpdateFormComponent } from './action-update-form.component';

describe('ActionUpdateFormComponent', () => {
  let component: ActionUpdateFormComponent;
  let fixture: ComponentFixture<ActionUpdateFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActionUpdateFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActionUpdateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
