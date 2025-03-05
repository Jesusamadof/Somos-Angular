import { TestBed } from '@angular/core/testing';

import { TipoRelacionService } from './tipo-relacion.service';

describe('TipoRelacionService', () => {
  let service: TipoRelacionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TipoRelacionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
