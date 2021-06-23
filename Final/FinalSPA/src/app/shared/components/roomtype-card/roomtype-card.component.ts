import { Component, Input, OnInit } from '@angular/core';
import { RoomtypeService } from 'src/app/core/services/roomtype.service';
import {Roomtype} from '../../../shared/models/roomtype';
@Component({
  selector: 'app-Roomtype-card',
  templateUrl: './Roomtype-card.component.html',
  styleUrls: ['./Roomtype-card.component.css']
})
export class RoomtypeCardComponent implements OnInit {
  @Input()Roomtypes!: Roomtype[];
  constructor(private RoomtypeService: RoomtypeService) { }
ngOnChanges(){
  //Called before any other lifecycle hook. Use it to inject dependencies, but avoid any serious work here.
  //Add '${implements OnChanges}' to the class.
  console.log('inside ngOnChanges method');
}
  ngOnInit() {
    console.log('inside ngOnInit method');
    this.RoomtypeService.getAllRoomtypes().subscribe(
      g=>{
        this.Roomtypes=g;
        console.log('Roomtype')
      }
    )
  }
ngOnDestroy() {
  //Called once, before the instance is destroyed.
  //Add 'implements OnDestroy' to the class.
  console.log('inside ngOnDestroy method');
}
}
