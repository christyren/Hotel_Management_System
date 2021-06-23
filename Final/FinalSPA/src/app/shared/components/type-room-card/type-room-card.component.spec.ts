import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TypeRoomCardComponent } from './type-room-card.component';

describe('TypeRoomCardComponent', () => {
  let component: TypeRoomCardComponent;
  let fixture: ComponentFixture<TypeRoomCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TypeRoomCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TypeRoomCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
