import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CorporationsPageComponent } from './corporations-page.component';

describe('CorporationsPageComponent', () => {
  let component: CorporationsPageComponent;
  let fixture: ComponentFixture<CorporationsPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CorporationsPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CorporationsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
