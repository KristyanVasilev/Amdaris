import { TestBed } from '@angular/core/testing';

import { UtensilService } from './utensil.service';

describe('UtensilService', () => {
  let service: UtensilService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UtensilService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
