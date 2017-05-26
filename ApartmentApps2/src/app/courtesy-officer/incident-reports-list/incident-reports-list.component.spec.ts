import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncidentReportsListComponent } from './incident-reports-list.component';

describe('IncidentReportsListComponent', () => {
  let component: IncidentReportsListComponent;
  let fixture: ComponentFixture<IncidentReportsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncidentReportsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncidentReportsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
