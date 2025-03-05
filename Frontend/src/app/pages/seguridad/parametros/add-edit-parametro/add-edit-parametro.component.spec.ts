import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditParametroComponent } from './add-edit-parametro.component';

describe('AddEditParametroComponent', () => {
  let component: AddEditParametroComponent;
  let fixture: ComponentFixture<AddEditParametroComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditParametroComponent]
    });
    fixture = TestBed.createComponent(AddEditParametroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
