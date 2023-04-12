import { TestBed } from '@angular/core/testing';

import { SensorDetailsService } from './sensor-details.service';

describe('SensorDetailsService', () => {
  let service: SensorDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SensorDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
