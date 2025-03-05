import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditOrientacionComponent } from './add-edit-orientacion.component';

describe('AddEditOrientacionComponent', () => {
  let component: AddEditOrientacionComponent;
  let fixture: ComponentFixture<AddEditOrientacionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditOrientacionComponent]
    });
    fixture = TestBed.createComponent(AddEditOrientacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
