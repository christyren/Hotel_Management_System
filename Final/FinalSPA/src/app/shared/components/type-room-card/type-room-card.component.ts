import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Room_Service } from 'src/app/core/services/room.service';
import { RoomtypeService } from 'src/app/core/services/roomtype.service';

@Component({
  selector: 'app-type-room-card',
  templateUrl: './type-room-card.component.html',
  styleUrls: ['./type-room-card.component.css']
})
export class TypeRoomCardComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
//employee - type, interactions - rooms