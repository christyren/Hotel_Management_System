
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RoomserviceService } from '../core/services/roomservice.service';
import { Roomservice } from '../shared/models/roomservice';


@Component({
  selector: 'app-Roomservice',
  templateUrl: './Roomservice.component.html',
  styleUrls: ['./Roomservice.component.css']
})
export class RoomserviceComponent implements OnInit {
  errInfo!:string;
  errFlg: boolean = false;
  tab: number = 1;
  roomservice: Roomservice = {
    Id: 0,
    RoomNo: 0,
    SDesc: '',
    Amount: 0,
    ServiceDate: ''
  };

  buttonType:string='Create';

  returnUrl: string="";
 
  constructor(private roomserviceService: RoomserviceService, private router: Router, 
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
    console.log(this.roomservice);
    console.log(buttonType);

    if (buttonType == 'Create') {
      this.roomserviceService.createRoomservice(this.roomservice).subscribe(
        (response:any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      );
    } else if (buttonType == 'Update') {
      this.roomserviceService.updateRoomservice(this.roomservice).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          } 
        },(err: any) => {
          this.errInfo= err.message;
          this.errFlg = true;
          if (err.status == 500) {
            this.errInfo = "Roomservice Not Found";
          }
          console.log(err);
        }

      )
    } else if (buttonType == 'Delete') {
      this.roomserviceService.deleteRoomservice(this.roomservice.Id).subscribe(
        (response: any) => {
          this.errFlg = false;
          this.router.navigate([this.returnUrl]);
        }
        
      );
    } else {
      // this.clean();

      this.roomserviceService.getRoomservice(this.roomservice.Id).subscribe(
        (response: any) => {
          // this.errFlg = false;
          // this.router.navigate(['']);myObservable.subscribe(
          console.log(response)
          this.roomservice = response
          console.log(this.roomservice)
          
        },        (err: any) => {
          this.errInfo = err.message;
          this.errFlg = true;
          if (err.status == 404) {
            this.errInfo = "Roomservice Not Found";
          }
          console.log(err);
        }
      
      );
      
    }
  
  };
}