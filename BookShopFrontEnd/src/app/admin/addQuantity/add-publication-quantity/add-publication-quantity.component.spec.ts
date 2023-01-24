import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPublicationQuantityComponent } from './add-publication-quantity.component';

describe('AddPublicationQuantityComponent', () => {
  let component: AddPublicationQuantityComponent;
  let fixture: ComponentFixture<AddPublicationQuantityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPublicationQuantityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPublicationQuantityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
