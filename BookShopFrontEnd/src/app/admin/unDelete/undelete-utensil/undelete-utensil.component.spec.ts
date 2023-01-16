import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UndeleteUtensilComponent } from './undelete-utensil.component';

describe('UndeleteUtensilComponent', () => {
  let component: UndeleteUtensilComponent;
  let fixture: ComponentFixture<UndeleteUtensilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UndeleteUtensilComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UndeleteUtensilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
