import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomServiceCardComponent } from './room-service-card.component';

describe('RoomServiceCardComponent', () => {
  let component: RoomServiceCardComponent;
  let fixture: ComponentFixture<RoomServiceCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomServiceCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomServiceCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
