import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrientacionComponent } from './orientacion.component';

describe('OrientacionComponent', () => {
  let component: OrientacionComponent;
  let fixture: ComponentFixture<OrientacionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrientacionComponent]
    });
    fixture = TestBed.createComponent(OrientacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
