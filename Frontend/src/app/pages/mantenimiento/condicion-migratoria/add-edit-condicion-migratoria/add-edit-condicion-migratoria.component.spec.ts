import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditCondicionMigratoriaComponent } from './add-edit-condicion-migratoria.component';

describe('AddEditCondicionMigratoriaComponent', () => {
  let component: AddEditCondicionMigratoriaComponent;
  let fixture: ComponentFixture<AddEditCondicionMigratoriaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditCondicionMigratoriaComponent]
    });
    fixture = TestBed.createComponent(AddEditCondicionMigratoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
