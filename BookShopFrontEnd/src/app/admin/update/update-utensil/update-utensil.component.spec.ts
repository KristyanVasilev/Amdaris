import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUtensilComponent } from './update-utensil.component';

describe('UpdateUtensilComponent', () => {
  let component: UpdateUtensilComponent;
  let fixture: ComponentFixture<UpdateUtensilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateUtensilComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateUtensilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
