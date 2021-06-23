import { Component, Input, OnInit } from '@angular/core';
import { RoomserviceService } from 'src/app/core/services/roomservice.service';
import {Roomservice} from '../../../shared/models/roomservice';
@Component({
  selector: 'app-Roomservice-card',
  templateUrl: './Roomservice-card.component.html',
  styleUrls: ['./Roomservice-card.component.css']
})
export class RoomserviceCardComponent implements OnInit {
  @Input()Roomservices!: Roomservice[];
  constructor(private RoomserviceService: RoomserviceService) { }
ngOnChanges(){
  //Called before any other lifecycle hook. Use it to inject dependencies, but avoid any serious work here.
  //Add '${implements OnChanges}' to the class.
  console.log('inside ngOnChanges method');
}
  ngOnInit() {
    console.log('inside ngOnInit method');
    this.RoomserviceService.getAllRoomservices().subscribe(
      g=>{
        this.Roomservices=g;
        console.log('Roomservice')
      }
    )
  }
ngOnDestroy() {
  //Called once, before the instance is destroyed.
  //Add 'implements OnDestroy' to the class.
  console.log('inside ngOnDestroy method');
}
}
