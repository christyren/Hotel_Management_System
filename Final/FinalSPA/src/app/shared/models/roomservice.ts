import { Room } from "./room";
export interface Roomservice{
    Id:number;
    RoomNo:number;
    SDesc:string;
    Amount:any;
    ServiceDate:string;
}

export interface ServicesUndCerRoomNo {
    userId: number;
    servicesForRoomNo: Roomservice[];
  }
  