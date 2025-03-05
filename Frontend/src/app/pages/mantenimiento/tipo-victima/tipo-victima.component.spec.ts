import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoVictimaComponent } from './tipo-victima.component';

describe('TipoVictimaComponent', () => {
  let component: TipoVictimaComponent;
  let fixture: ComponentFixture<TipoVictimaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TipoVictimaComponent]
    });
    fixture = TestBed.createComponent(TipoVictimaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
