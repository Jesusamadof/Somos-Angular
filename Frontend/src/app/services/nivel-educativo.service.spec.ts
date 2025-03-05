import { TestBed } from '@angular/core/testing';

import { NivelEducativoService } from './nivel-educativo.service';

describe('NivelEducativoService', () => {
  let service: NivelEducativoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NivelEducativoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
