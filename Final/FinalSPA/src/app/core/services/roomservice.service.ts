import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Roomservice } from 'src/app/shared/models/roomservice';
import { ApiService } from './api.service';
  
@Injectable({
  providedIn: 'root'
})

export class RoomserviceService {
  constructor(private apiService: ApiService) { }
  
  getAllRoomservices(): Observable<Roomservice[]> {

    return this.apiService.getAll('Roomservice/All');
  }
    
  getRoomservice(id:number): Observable<Roomservice> {
   
    return this.apiService.getOne('Roomservice',id);
  }
  createRoomservice(resource: any): Observable<Roomservice> {
    return this.apiService.create('Roomservice/add', resource);
  }
  updateRoomservice(resource: any): Observable<Roomservice> {
    return this.apiService.update('Roomservice/update?id=', resource);
  }
  deleteRoomservice(resource: any): Observable<Roomservice> {
    return this.apiService.delete('Roomservice/delete?id=' + resource);
  }


}
