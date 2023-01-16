import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UtensilBoxComponent } from './utensil-box.component';

describe('UtensilBoxComponent', () => {
  let component: UtensilBoxComponent;
  let fixture: ComponentFixture<UtensilBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UtensilBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UtensilBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
