import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HechoComponent } from './hecho.component';

describe('HechoComponent', () => {
  let component: HechoComponent;
  let fixture: ComponentFixture<HechoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HechoComponent]
    });
    fixture = TestBed.createComponent(HechoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
