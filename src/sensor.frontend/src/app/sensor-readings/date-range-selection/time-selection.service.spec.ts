import { TestBed } from '@angular/core/testing';

import { TimeSelectionService } from './time-selection.service';

describe('TimeSelectionService', () => {
  let service: TimeSelectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TimeSelectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
