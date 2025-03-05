import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditHechoComponent } from './add-edit-hecho.component';

describe('AddEditHechoComponent', () => {
  let component: AddEditHechoComponent;
  let fixture: ComponentFixture<AddEditHechoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditHechoComponent]
    });
    fixture = TestBed.createComponent(AddEditHechoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
