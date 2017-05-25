import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CorporationsFormComponent } from './corporations-form.component';

describe('CorporationsFormComponent', () => {
  let component: CorporationsFormComponent;
  let fixture: ComponentFixture<CorporationsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CorporationsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CorporationsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
