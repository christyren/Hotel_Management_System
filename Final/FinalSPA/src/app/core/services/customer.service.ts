import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from 'src/app/shared/models/customer';
import { ApiService } from './api.service';
  
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(private apiService: ApiService) { }
  
  getAllCustomers(): Observable<Customer[]> {

    return this.apiService.getAll('Customer/all');
  }
    
  getCustomer(id:number): Observable<Customer> {
   
    return this.apiService.getOne('Customer',id);
  }
  createCustomer(resource: any): Observable<Customer> {
    return this.apiService.create('Customer/add', resource);
  }
  updateCustomer(resource: any): Observable<Customer> {
    return this.apiService.update('Customer/update?id=', resource);
  }
  deleteCustomer(resource: any): Observable<Customer> {
    return this.apiService.delete('Customer/delete?id=' + resource);
  }

}