import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NgModule } from '@angular/core';
import { CustomerCardComponent } from './customer-card.component';

describe('CustomerCardComponent', () => {
  let component: CustomerCardComponent;
  let fixture: ComponentFixture<CustomerCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
