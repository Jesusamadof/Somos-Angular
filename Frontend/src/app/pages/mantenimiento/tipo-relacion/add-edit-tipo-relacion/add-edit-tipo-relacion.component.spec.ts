import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditTipoRelacionComponent } from './add-edit-tipo-relacion.component';

describe('AddEditTipoRelacionComponent', () => {
  let component: AddEditTipoRelacionComponent;
  let fixture: ComponentFixture<AddEditTipoRelacionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditTipoRelacionComponent]
    });
    fixture = TestBed.createComponent(AddEditTipoRelacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
