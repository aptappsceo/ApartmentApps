import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CorporationsListComponent } from './corporations-list.component';

describe('CorporationsListComponent', () => {
  let component: CorporationsListComponent;
  let fixture: ComponentFixture<CorporationsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CorporationsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CorporationsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
