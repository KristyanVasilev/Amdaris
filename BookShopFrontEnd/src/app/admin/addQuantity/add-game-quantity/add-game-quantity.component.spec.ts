import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGameQuantityComponent } from './add-game-quantity.component';

describe('AddGameQuantityComponent', () => {
  let component: AddGameQuantityComponent;
  let fixture: ComponentFixture<AddGameQuantityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddGameQuantityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddGameQuantityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
