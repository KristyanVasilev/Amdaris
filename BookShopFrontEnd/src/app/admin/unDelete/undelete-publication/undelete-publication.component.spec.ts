import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UndeletePublicationComponent } from './undelete-publication.component';

describe('UndeletePublicationComponent', () => {
  let component: UndeletePublicationComponent;
  let fixture: ComponentFixture<UndeletePublicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UndeletePublicationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UndeletePublicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
