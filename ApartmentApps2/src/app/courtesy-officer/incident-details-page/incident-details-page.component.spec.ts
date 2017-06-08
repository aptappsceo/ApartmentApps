import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncidentDetailsPageComponent } from './incident-details-page.component';

describe('IncidentDetailsPageComponent', () => {
  let component: IncidentDetailsPageComponent;
  let fixture: ComponentFixture<IncidentDetailsPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncidentDetailsPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncidentDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
