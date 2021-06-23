import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RoomtypeService } from '../core/services/roomtype.service';
import { Roomtype } from '../shared/models/roomtype';


@Component({
  selector: 'app-roomtype',
  templateUrl: './roomtype.component.html',
  styleUrls: ['./roomtype.component.css']
})
export class RoomtypeComponent implements OnInit {
  errInfo!:string;
  errFlg: boolean = false;
  tab: number = 1;
  roomtype: Roomtype = {
    Id:0,
    RTDesc: '',
    Rent: ''
  };

  buttonType:string='Create';

  returnUrl: string="";
 
  constructor(private roomtypeService: RoomtypeService, private router: Router, 
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
    console.log(this.roomtype);
    console.log(buttonType);

    if (buttonType == 'Create') {
      this.roomtypeService.createRoomtype(this.roomtype).subscribe(
        (response:any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      );
    } else if (buttonType == 'Update') {
      this.roomtypeService.updateRoomtype(this.roomtype).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          } 
        },(err: any) => {
          this.errInfo= err.message;
          this.errFlg = true;
          if (err.status == 500) {
            this.errInfo = "Roomtype Not Found";
          }
          console.log(err);
        }

      )
    } else if (buttonType == 'Delete') {
      this.roomtypeService.deleteRoomtype(this.roomtype.Id).subscribe(
        (response: any) => {
          this.errFlg = false;
          this.router.navigate([this.returnUrl]);
        }
        
      );
    } else {
      // this.clean();

      this.roomtypeService.getRoomtype(this.roomtype.Id).subscribe(
        (response: any) => {
          // this.errFlg = false;
          // this.router.navigate(['']);myObservable.subscribe(
          console.log(response)
          this.roomtype = response
          console.log(this.roomtype)
          
        },        (err: any) => {
          this.errInfo = err.message;
          this.errFlg = true;
          if (err.status == 404) {
            this.errInfo = "Roomtype Not Found";
          }
          console.log(err);
        }
      
      );
      
    }
  
  };
}