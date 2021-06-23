import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomCustomerCardComponent } from './room-customer-card.component';

describe('RoomCustomerCardComponent', () => {
  let component: RoomCustomerCardComponent;
  let fixture: ComponentFixture<RoomCustomerCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomCustomerCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomCustomerCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
