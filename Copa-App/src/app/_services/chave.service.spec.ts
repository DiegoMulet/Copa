/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ChaveService } from './chave.service';

describe('Service: Chave', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ChaveService]
    });
  });

  it('should ...', inject([ChaveService], (service: ChaveService) => {
    expect(service).toBeTruthy();
  }));
});
