import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CondicionMigratoriaComponent } from './condicion-migratoria.component';

describe('CondicionMigratoriaComponent', () => {
  let component: CondicionMigratoriaComponent;
  let fixture: ComponentFixture<CondicionMigratoriaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CondicionMigratoriaComponent]
    });
    fixture = TestBed.createComponent(CondicionMigratoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
