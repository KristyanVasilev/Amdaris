import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUtensilQuantityComponent } from './add-utensil-quantity.component';

describe('AddUtensilQuantityComponent', () => {
  let component: AddUtensilQuantityComponent;
  let fixture: ComponentFixture<AddUtensilQuantityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUtensilQuantityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddUtensilQuantityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
