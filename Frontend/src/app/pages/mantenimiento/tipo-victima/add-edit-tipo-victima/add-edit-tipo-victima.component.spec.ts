import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditTipoVictimaComponent } from './add-edit-tipo-victima.component';

describe('AddEditTipoVictimaComponent', () => {
  let component: AddEditTipoVictimaComponent;
  let fixture: ComponentFixture<AddEditTipoVictimaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditTipoVictimaComponent]
    });
    fixture = TestBed.createComponent(AddEditTipoVictimaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
