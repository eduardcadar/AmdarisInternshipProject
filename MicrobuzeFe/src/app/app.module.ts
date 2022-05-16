import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TripsListComponent } from './pages/trips/trips-list/trips-list.component';
import { RegularUserProfileComponent } from './pages/regular-user-profile/regular-user-profile.component';
import { NavbarComponent } from './pages/navbar/navbar.component';
import { LoginRegularComponent } from './pages/login-regular/login-regular.component';
import { LoginAgencyComponent } from './pages/login-agency/login-agency.component';
import { LoginChooseComponent } from './pages/login-choose/login-choose.component';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { TripService } from './services/trip-service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateTripFormComponent } from './pages/trips/create-trip-form/create-trip-form.component';
import { SearchTripComponent } from './pages/trips/search-trip/search-trip.component';
import { ReservationsListComponent } from './pages/regular-user-profile/reservations-list/reservations-list.component';
import { ReservationsService } from './services/reservations-service';

@NgModule({
  declarations: [
    AppComponent,
    TripsListComponent,
    CreateTripFormComponent,
    RegularUserProfileComponent,
    LoginRegularComponent,
    NavbarComponent,
    LoginAgencyComponent,
    LoginChooseComponent,
    HomepageComponent,
    NotFoundComponent,
    SearchTripComponent,
    ReservationsListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  providers: [
    TripService,
    ReservationsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
