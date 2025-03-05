import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditVictiComponent } from './add-edit-victi.component';

describe('AddEditVictiComponent', () => {
  let component: AddEditVictiComponent;
  let fixture: ComponentFixture<AddEditVictiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditVictiComponent]
    });
    fixture = TestBed.createComponent(AddEditVictiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
