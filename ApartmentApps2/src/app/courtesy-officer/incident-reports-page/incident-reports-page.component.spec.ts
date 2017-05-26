import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncidentReportsPageComponent } from './incident-reports-page.component';

describe('IncidentReportsPageComponent', () => {
  let component: IncidentReportsPageComponent;
  let fixture: ComponentFixture<IncidentReportsPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncidentReportsPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncidentReportsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
