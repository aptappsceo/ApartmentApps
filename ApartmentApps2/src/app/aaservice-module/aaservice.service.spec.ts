import { TestBed, inject } from '@angular/core/testing';

import { AAServiceService } from './aaservice.service';

describe('AAServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AAServiceService]
    });
  });

  it('should ...', inject([AAServiceService], (service: AAServiceService) => {
    expect(service).toBeTruthy();
  }));
});
