import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteUtensilComponent } from './delete-utensil.component';

describe('DeleteUtensilComponent', () => {
  let component: DeleteUtensilComponent;
  let fixture: ComponentFixture<DeleteUtensilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteUtensilComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteUtensilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
