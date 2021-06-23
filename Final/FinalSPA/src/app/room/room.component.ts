
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Room_Service } from '../core/services/room.service';
import { Room } from '../shared/models/room';


@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {
  errInfo!:string;
  errFlg: boolean = false;
  tab: number = 1;
  room: Room = {
    Id: 0,
    RTCode: 0,
    Status: 0
  };
  buttonType:string='Create';

  returnUrl: string="";
 
  constructor(private roomService: Room_Service, private router: Router, 
    private route: ActivatedRoute) { }

  ngOnChanges() {
    console.log('inside ngOnChanges method');
  }
  // this were we call our API to get the data
  ngOnInit(): void {
    this.route.queryParams.subscribe(
      (params) => (this.returnUrl = params.returnUrl || '/')
    );
  }
  ngOnDestroy() {
    console.log('inside ngOnDestroy method');
  }


  submit(buttonType: string) {
    console.log(this.room);
    console.log(buttonType);

    if (buttonType == 'Create') {
      this.roomService.createRoom(this.room).subscribe(
        (response:any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      );
    } else if (buttonType == 'Update') {
      this.roomService.updateRoom(this.room).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          } 
        },(err: any) => {
          this.errInfo= err.message;
          this.errFlg = true;
          if (err.status == 500) {
            this.errInfo = "User Not Found";
          }
          console.log(err);
        }

      )
    } else if (buttonType == 'Delete') {
      this.roomService.deleteRoom(this.room.Id).subscribe(
        (response: any) => {
          this.errFlg = false;
          this.router.navigate([this.returnUrl]);
        }
        
      );
    } else {
      // this.clean();

      this.roomService.getRoom(this.room.Id).subscribe(
        (response: any) => {
          // this.errFlg = false;
          // this.router.navigate(['']);myObservable.subscribe(
          console.log(response)
          this.room = response
          console.log(this.room)
          
        },        (err: any) => {
          this.errInfo = err.message;
          this.errFlg = true;
          if (err.status == 404) {
            this.errInfo = "User Not Found";
          }
          console.log(err);
        }
      
      );
      
    }
  
  };
}