import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { RoomComponent } from './room/room.component';
import { RoomserviceComponent } from './roomservice/roomservice.component';
import { RoomtypeComponent } from './roomtype/roomtype.component';
import { RoomServiceCardComponent } from './shared/components/room-service-card/room-service-card.component';
import {HomeComponent} from './home/home.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { CustomerCardComponent } from './shared/components/customer-card/customer-card.component';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
const routes: Routes = [
  {path: "", component : HomeComponent},
  {path: 'customer', component: CustomerComponent},
  {path: 'room', component: RoomComponent},
  {path: 'roomtype', component: RoomtypeComponent},
  {path: 'roomservice', component: RoomserviceComponent},

  {path:'room/services/:id',component:RoomServiceCardComponent},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path: "**", component: NotFoundComponent}

 
];

@NgModule({
  imports: [RouterModule.forRoot(routes),CommonModule,FormsModule],
  exports: [RouterModule,CommonModule,FormsModule,ReactiveFormsModule]
})
export class AppRoutingModule { }

