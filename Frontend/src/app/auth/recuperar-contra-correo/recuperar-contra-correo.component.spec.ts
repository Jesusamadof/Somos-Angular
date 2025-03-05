import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecuperarContraCorreoComponent } from './recuperar-contra-correo.component';

describe('RecuperarContraCorreoComponent', () => {
  let component: RecuperarContraCorreoComponent;
  let fixture: ComponentFixture<RecuperarContraCorreoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RecuperarContraCorreoComponent]
    });
    fixture = TestBed.createComponent(RecuperarContraCorreoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
