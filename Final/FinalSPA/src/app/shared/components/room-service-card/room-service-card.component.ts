import { Component, Input, OnInit } from '@angular/core';
import { Room_Service } from 'src/app/core/services/room.service';
import { RoomserviceService } from 'src/app/core/services/roomservice.service';
import { Roomservice } from '../../models/roomservice';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-room-services',
  templateUrl: './room-service-card.component.html',
  styleUrls: ['./room-service-card.component.css']
})
export class RoomServiceCardComponent implements OnInit {
  RoomNo!: number;
  services :any;
  private sub:any;
  returnUrl: string = "";
  @Input()roomservices!: Roomservice[];
  constructor(private roomService: Room_Service,private route: ActivatedRoute) { 
    // this.route.queryParams.subscribe(params => {
    //   let RoomNo = params['RoomNo'];
    //   console.log(RoomNo);
    // });
  }

  //-------------------------------------------------------------
  // ngOnInit() {
    // this.sub = this.router.params.subscribe(params=>{this.RoomNo = +params['id'];});

    // this.services = this.roomService.getRoomservicesByRoomNo(this.RoomNo).subscribe(
    //   g => {
    //     this.services = g;
    //     console.log("Got the room services")
    //     console.table(this.services)
    //   }
    // )
    //--------------------------------------------------------------------
    // ngOnInit() {
    //   this.route.queryParams.subscribe(
    //     // (params) => (this.returnUrl = params.returnUrl || '/')
    //     params => {
    //       this.RoomNo = + params.get('RoomNo');
    //       this.roomService.getRoomservicesByRoomNo(this.RoomNo)
    //         .subscribe(g => {
    //           this.services = g;
    //         });
    //     }
    //   );
    // }

    //--------------------------------------------------------------------
      // this.route.paramMap.subscribe(
      //   params => {
      //     this.RoomNo = + params.get('RoomNo');
      //     this.roomService.getRoomservicesByRoomNo(this.RoomNo)
      //       .subscribe(g => {
      //         this.services = g;
      //       });
      //   }
      // );


      ngOnInit() {

        this.RoomNo = this.route.snapshot.params.id;
        console.log(this.RoomNo)
      
      // this.sub = this.route.params.subscribe(params=>{this.RoomNo = +params['RoomNo'];});
    // console.log(this.sub)
      this.services= this.roomService.getRoomservicesByRoomNo(this.RoomNo)
      .subscribe(g => {
        this.services = g;
        console.log("Succeed get the services")
        console.table(this.services);
      });
    }
 }