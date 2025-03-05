import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaVictimasComponent } from './lista-victimas.component';

describe('ListaVictimasComponent', () => {
  let component: ListaVictimasComponent;
  let fixture: ComponentFixture<ListaVictimasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListaVictimasComponent]
    });
    fixture = TestBed.createComponent(ListaVictimasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
