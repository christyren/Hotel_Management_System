import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Room } from 'src/app/shared/models/room';
import { ApiService } from './api.service';
import { Roomservice } from 'src/app/shared/models/roomservice';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class Room_Service {
  // RoomNo!:Number;
  // private servicesUnderRoomNoSubject = new BehaviorSubject<ServicesUndCerRoomNo>(null);
  // servicesUnderRoomNo = this.servicesUnderRoomNoSubject.asObservable();
  constructor(private apiService: ApiService) { }
  
  getAllRooms(): Observable<Room[]> {

    return this.apiService.getAll('Room/all');
  }
    
  getRoom(id:number): Observable<Room> {
   
    return this.apiService.getOne('Room',id);
  }
  createRoom(resource: any): Observable<Room> {
    return this.apiService.create('Room/add', resource);
  }
  updateRoom(resource: any): Observable<Room> {
    return this.apiService.update('Room/update?id=', resource);
  }
  deleteRoom(resource: any): Observable<Room> {
    return this.apiService.delete('Room/delete?id=' + resource);
  }

  getRoomservicesByRoomNo(RoomNo:number): Observable<Roomservice[]>{
    return this.apiService.getAll("Roomservice/RoomservicesByRoomNo?RoomNo="+RoomNo);
  }
  // getByRoomtypeId(id:number): Observable<Room[]> {
  // }


}