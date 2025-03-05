import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditVictimaComponent } from './add-edit-victima.component';

describe('AddEditVictimaComponent', () => {
  let component: AddEditVictimaComponent;
  let fixture: ComponentFixture<AddEditVictimaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditVictimaComponent]
    });
    fixture = TestBed.createComponent(AddEditVictimaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
