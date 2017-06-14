import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenanceDetailsPageComponent } from './maintenance-details-page.component';

describe('MaintenanceDetailsPageComponent', () => {
  let component: MaintenanceDetailsPageComponent;
  let fixture: ComponentFixture<MaintenanceDetailsPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaintenanceDetailsPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenanceDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
