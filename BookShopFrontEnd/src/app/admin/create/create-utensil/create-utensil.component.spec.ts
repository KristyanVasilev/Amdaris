import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateUtensilComponent } from './create-utensil.component';

describe('CreateUtensilComponent', () => {
  let component: CreateUtensilComponent;
  let fixture: ComponentFixture<CreateUtensilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateUtensilComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateUtensilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
