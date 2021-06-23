
import {Room} from "./room"

export interface Customer{
    id:number;
    roomNo:number;
    cName:string;
    address:string;
    phone:string;
    email:string;
    checkin:string;  //before is Date type
    totalPersons:number;
    bookingDays:number;
    advance:any;
    // Room:Room;

}