import { TestBed } from '@angular/core/testing';

import { DashboardConfigurationService } from './dashboard-configuration.service';

describe('DashboardConfigurationService', () => {
  let service: DashboardConfigurationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DashboardConfigurationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
