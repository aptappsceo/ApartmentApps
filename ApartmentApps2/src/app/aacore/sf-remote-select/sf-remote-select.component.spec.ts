import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SfRemoteSelectComponent } from './sf-remote-select.component';

describe('SfRemoteSelectComponent', () => {
  let component: SfRemoteSelectComponent;
  let fixture: ComponentFixture<SfRemoteSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SfRemoteSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SfRemoteSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
