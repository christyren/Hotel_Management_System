import { Component, Input, OnInit } from '@angular/core';
import { Room_Service } from 'src/app/core/services/room.service';
import { RoomserviceService } from 'src/app/core/services/roomservice.service';
import {Room} from '../../../shared/models/room';
@Component({
  selector: 'app-room-card',
  templateUrl: './room-card.component.html',
  styleUrls: ['./room-card.component.css']
})
export class RoomCardComponent implements OnInit {
  @Input()Rooms!: Room[];
  constructor(private RoomService: Room_Service,RoomserviceService:RoomserviceService) { }
ngOnChanges(){
  //Called before any other lifecycle hook. Use it to inject dependencies, but avoid any serious work here.
  //Add '${implements OnChanges}' to the class.
  console.log('inside ngOnChanges method');
}
  ngOnInit() {
    console.log('inside ngOnInit method');
    this.RoomService.getAllRooms().subscribe(
      g=>{
        this.Rooms=g;
        console.log('Room')
      }
    )
  }
ngOnDestroy() {
  //Called once, before the instance is destroyed.
  //Add 'implements OnDestroy' to the class.
  console.log('inside ngOnDestroy method');
}
}
