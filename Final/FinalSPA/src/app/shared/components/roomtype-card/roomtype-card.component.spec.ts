import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomtypeCardComponent } from './roomtype-card.component';

describe('RoomtypeCardComponent', () => {
  let component: RoomtypeCardComponent;
  let fixture: ComponentFixture<RoomtypeCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomtypeCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomtypeCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
