import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomserviceCardComponent } from './roomservice-card.component';

describe('RoomserviceCardComponent', () => {
  let component: RoomserviceCardComponent;
  let fixture: ComponentFixture<RoomserviceCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomserviceCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomserviceCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
