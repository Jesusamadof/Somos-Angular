import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VictimasComponent } from './victimas.component';

describe('VictimasComponent', () => {
  let component: VictimasComponent;
  let fixture: ComponentFixture<VictimasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VictimasComponent]
    });
    fixture = TestBed.createComponent(VictimasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
