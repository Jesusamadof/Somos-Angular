import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditObjetoComponent } from './add-edit-objeto.component';

describe('AddEditObjetoComponent', () => {
  let component: AddEditObjetoComponent;
  let fixture: ComponentFixture<AddEditObjetoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditObjetoComponent]
    });
    fixture = TestBed.createComponent(AddEditObjetoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
