import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoRelacionComponent } from './tipo-relacion.component';

describe('TipoRelacionComponent', () => {
  let component: TipoRelacionComponent;
  let fixture: ComponentFixture<TipoRelacionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TipoRelacionComponent]
    });
    fixture = TestBed.createComponent(TipoRelacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
