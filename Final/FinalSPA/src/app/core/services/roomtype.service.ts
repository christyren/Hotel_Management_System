import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Roomtype } from 'src/app/shared/models/roomtype';
import { ApiService } from './api.service';
  
@Injectable({
  providedIn: 'root'
})

export class RoomtypeService {
  constructor(private apiService: ApiService) { }
  
  getAllRoomtypes(): Observable<Roomtype[]> {

    return this.apiService.getAll('Roomtype/All');
  }
    
  getRoomtype(id:number): Observable<Roomtype> {
   
    return this.apiService.getOne('Roomtype',id);
  }
  createRoomtype(resource: any): Observable<Roomtype> {
    return this.apiService.create('Roomtype/add', resource);
  }
  updateRoomtype(resource: any): Observable<Roomtype> {
    return this.apiService.update('Roomtype/update?id=', resource);
  }
  deleteRoomtype(resource: any): Observable<Roomtype> {
    return this.apiService.delete('Roomtype/delete?id=' + resource);
  }

}
