import { Component, Input, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/core/services/customer.service';
import {Customer} from '../../../shared/models/customer';
import { NgModule } from '@angular/core';

import { CustomerCard } from '../../models/customer-card';

@Component({
  selector: 'app-customer-card',
  templateUrl: './customer-card.component.html',
  styleUrls: ['./customer-card.component.css']
})
export class CustomerCardComponent implements OnInit {
  // @Input()
  // customer!: Customer;
  constructor() { }

  ngOnInit(): void {

    // console.log(this.customer);
  }

}
