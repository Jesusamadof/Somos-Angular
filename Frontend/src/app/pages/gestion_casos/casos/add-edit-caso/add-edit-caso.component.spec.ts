import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditCasoComponent } from './add-edit-caso.component';

describe('AddEditCasoComponent', () => {
  let component: AddEditCasoComponent;
  let fixture: ComponentFixture<AddEditCasoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditCasoComponent]
    });
    fixture = TestBed.createComponent(AddEditCasoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
