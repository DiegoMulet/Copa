/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SelecaoService } from './selecao.service';

describe('Service: Selecao', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SelecaoService]
    });
  });

  it('should ...', inject([SelecaoService], (service: SelecaoService) => {
    expect(service).toBeTruthy();
  }));
});
