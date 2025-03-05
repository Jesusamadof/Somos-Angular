import { TestBed } from '@angular/core/testing';

import { HechoService } from './hecho.service';

describe('HechoService', () => {
  let service: HechoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HechoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
