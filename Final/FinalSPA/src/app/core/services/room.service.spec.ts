import { TestBed } from '@angular/core/testing';

import { Room_Service } from './room.service';

describe('RoomService', () => {
  let service: Room_Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Room_Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
