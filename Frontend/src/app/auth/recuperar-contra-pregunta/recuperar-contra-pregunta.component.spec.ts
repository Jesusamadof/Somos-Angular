import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecuperarContraPreguntaComponent } from './recuperar-contra-pregunta.component';

describe('RecuperarContraPreguntaComponent', () => {
  let component: RecuperarContraPreguntaComponent;
  let fixture: ComponentFixture<RecuperarContraPreguntaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RecuperarContraPreguntaComponent]
    });
    fixture = TestBed.createComponent(RecuperarContraPreguntaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
