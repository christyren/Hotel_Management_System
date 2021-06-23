
import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerService } from '../core/services/customer.service';
import { Customer } from '../shared/models/customer';

@Component({
  selector: 'app-Employee',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  // this property will be available to view so that it can use to display data
  errInfo!:string;
  errFlg: boolean = false;
  tab: number = 1;
  customer: Customer = {
    id:0,
    roomNo: 0,
    cName: '',
    address: '',
    phone: '',
    email: '',
    checkin: '',
    totalPersons:0,
    bookingDays:0,
    advance: 0
  };



  buttonType:string='Create';

  returnUrl: string="";
 
  constructor(private customerService: CustomerService, private router: Router, 
    private route: ActivatedRoute) { }

  ngOnChanges() {
    console.log('inside ngOnChanges method');
  }
  // this were we call our API to get the data
  ngOnInit(): void {
    this.route.queryParams.subscribe(
      (params) => (this.returnUrl = params.returnUrl || '/')
    );
  }
  ngOnDestroy() {
    console.log('inside ngOnDestroy method');
  }


  submit(buttonType: string) {
    console.log(this.customer);
    console.log(buttonType);

    if (buttonType == 'Create') {
      this.customerService.createCustomer(this.customer).subscribe(
        (response:any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      );
    } else if (buttonType == 'Update') {
      this.customerService.updateCustomer(this.customer).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          } 
        },(err: any) => {
          this.errInfo= err.message;
          this.errFlg = true;
          if (err.status == 500) {
            this.errInfo = "User Not Found";
          }
          console.log(err);
        }

      )
    } else if (buttonType == 'Delete') {
      this.customerService.deleteCustomer(this.customer.id).subscribe(
        (response: any) => {
          this.errFlg = false;
          this.router.navigate([this.returnUrl]);
        }
        
      );
    } else if (buttonType == 'Search') {
      // this.clean();

      this.customerService.getCustomer(this.customer.id).subscribe(
        (response: any) => {
          // this.errFlg = false;
          // this.router.navigate(['']);myObservable.subscribe(
          console.log(response)
          this.customer = response
          console.log(this.customer)
          
        },        (err: any) => {
          this.errInfo = err.message;
          this.errFlg = true;
          if (err.status == 404) {
            this.errInfo = "User Not Found";
          }
          console.log(err);
        }
      
      );
      
    }
  
  };
}