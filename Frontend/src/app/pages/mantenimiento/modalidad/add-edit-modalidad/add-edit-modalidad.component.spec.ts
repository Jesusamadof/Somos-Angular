import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditModalidadComponent } from './add-edit-modalidad.component';

describe('AddEditModalidadComponent', () => {
  let component: AddEditModalidadComponent;
  let fixture: ComponentFixture<AddEditModalidadComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditModalidadComponent]
    });
    fixture = TestBed.createComponent(AddEditModalidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
