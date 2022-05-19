import { TestBed } from '@angular/core/testing';

import { ServiceblogService } from './blog-service.service';

describe('BlogServiceService', () => {
  let service: ServiceblogService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceblogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
