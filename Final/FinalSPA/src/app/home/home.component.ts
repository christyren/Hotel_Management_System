import { Component, OnInit } from '@angular/core';
import { CustomerCard } from '../shared/models/customer-card';
import { CustomerService } from '../core/services/customer.service';
import { ActivatedRoute } from '@angular/router';
import { Customer } from '../shared/models/customer';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private customerService: CustomerService,private router: ActivatedRoute) { }

// customers!: Customer[];
    customers!: any[];

ngOnChanges(){
  //Called before any other lifecycle hook. Use it to inject dependencies, but avoid any serious work here.
  //Add '${implements OnChanges}' to the class.
  console.log('inside ngOnChanges method');
}
  // ngOnInit() {
  //   console.log('inside ngOnInit method');
  //   this.customerService.getAllCustomers().subscribe(
  //     g=>{
  //       this.customers=g;
  //     }
  //   )
  // }

    ngOnInit() {

    // console.log('inside ngOnInit method');
    // this.sub = this.router.params.subscribe(params=>{this.customers});
    // this.customers = this.customerService.getAllCustomers().subscribe(
    //   g=>{
    //     this.customers=g;
    //     console.log("Succed get the customers")
    //   }
    // )

    this.customerService.getAllCustomers().subscribe(

      m => {
        this.customers = m;
        console.log('inside Home Component');
        //console.log(this.movies);
        console.table(this.customers);
      }

    );
  }
ngOnDestroy() {
  //Called once, before the instance is destroyed.
  //Add 'implements OnDestroy' to the class.
  console.log('inside ngOnDestroy method')
}
}