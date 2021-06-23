import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { RoomComponent } from './room/room.component';
import { RoomserviceComponent } from './roomservice/roomservice.component';
import { RoomtypeComponent } from './roomtype/roomtype.component';
import { RoomServiceCardComponent } from './shared/components/room-service-card/room-service-card.component';
import { CustomerCardComponent } from './shared/components/customer-card/customer-card.component';
import { RoomCardComponent } from './shared/components/room-card/room-card.component';
import { RoomtypeCardComponent } from './shared/components/roomtype-card/roomtype-card.component';
import { RoomtypeService } from './core/services/roomtype.service';
import { RoomserviceService } from './core/services/roomservice.service';
import { CustomerService } from './core/services/customer.service';
import { Room_Service } from './core/services/room.service';
import { TypeRoomCardComponent } from './shared/components/type-room-card/type-room-card.component';
import { RoomserviceCardComponent } from './shared/components/roomservice-card/roomservice-card.component';
import { RoomCustomerCardComponent } from './shared/components/room-customer-card/room-customer-card.component';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    NotFoundComponent,
    CustomerComponent,
    RoomComponent,
    RoomserviceComponent,
    RoomtypeComponent,
    RoomServiceCardComponent,
    CustomerCardComponent,
    RoomCardComponent,
    RoomtypeCardComponent,
    TypeRoomCardComponent,
    RoomserviceCardComponent,
    RoomCustomerCardComponent,
    LoginComponent,
    RegisterComponent


  ],
  imports: [
    // BrowserModule,
    // AppRoutingModule,
    // HttpClientModule,
    // NgbModule,
    // FormsModule,ReactiveFormsModule,
    // NgModule,
    // RouterModule
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,ReactiveFormsModule,
    NgbModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]

})
export class AppModule { }
