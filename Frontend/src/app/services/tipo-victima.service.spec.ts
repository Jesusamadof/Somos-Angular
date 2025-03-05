import { TestBed } from '@angular/core/testing';

import { TipoVictimaService } from './tipo-victima.service';

describe('TipoVictimaService', () => {
  let service: TipoVictimaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TipoVictimaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
