import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UndeleteGameComponent } from './undelete-game.component';

describe('UndeleteGameComponent', () => {
  let component: UndeleteGameComponent;
  let fixture: ComponentFixture<UndeleteGameComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UndeleteGameComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UndeleteGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
