
import {Room} from "./room"

export interface Customer{
    id:number;
    RoomNo:number;
    CName:string;
    Address:string;
    Phone:string;
    Email:string;
    Checkin:string;  //before is Date type
    TotalPersons:number;
    BookingDays:number;
    Advance:any;
    // Room:Room;

}