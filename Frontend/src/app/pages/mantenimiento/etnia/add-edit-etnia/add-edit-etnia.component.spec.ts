import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditEtniaComponent } from './add-edit-etnia.component';

describe('AddEditEtniaComponent', () => {
  let component: AddEditEtniaComponent;
  let fixture: ComponentFixture<AddEditEtniaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditEtniaComponent]
    });
    fixture = TestBed.createComponent(AddEditEtniaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
