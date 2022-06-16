import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppsRoutingModule } from './apps-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppsComponent } from './apps.component';
import { TripsListComponent } from './trips/trips-list/trips-list.component';
import { AboutComponent } from './about/about.component';

import { FullComponent } from './layout/full/full.component';

import { BannerComponent } from './shared/banner/banner.component';
import { BannerNavigationComponent } from './shared/banner-navigation/banner-navigation.component';
import { FooterComponent } from './shared/footer/footer.component';
import { SearchTripComponent } from './trips/search-trip/search-trip.component';
import { ReservationsListComponent } from './about/regular-user-profile/reservations-list/reservations-list.component';
import { ReserveButtonComponent } from './trips/reserve-button/reserve-button.component';
import { CreateTripComponent } from './trips/create-trip/create-trip.component';
import { UpdateReservationComponent } from './about/regular-user-profile/update-reservation/update-reservation.component';
import { LoginComponent } from './account/login/login.component';
import { LoginFormComponent } from './account/login/login-form/login-form.component';
import { RegisterComponent } from './account/register/register.component';
import { RegisterRegularuserFormComponent } from './account/register/register-regularuser-form/register-regularuser-form.component';
import { RegisterAgencyuserFormComponent } from './account/register/register-agencyuser-form/register-agencyuser-form.component';
import { AuthenticationInterceptor } from './interceptors/authentication.interceptor';
import { ReservationsService } from './services/reservations-service';
import { TripService } from './services/trip-service';
import { AgencyUserProfileComponent } from './about/agency-user-profile/agency-user-profile.component';
import { RegularUserProfileComponent } from './about/regular-user-profile/regular-user-profile.component';
import { AgencyTripsListComponent } from './about/agency-user-profile/agency-trips-list/agency-trips-list.component';

@NgModule({
  declarations: [
    AppsComponent,
    TripsListComponent,
    AboutComponent,
    FullComponent,
    BannerComponent,
    // BannerContentComponent,
    BannerNavigationComponent,
    FooterComponent,
    SearchTripComponent,
    ReservationsListComponent,
    ReserveButtonComponent,
    CreateTripComponent,
    UpdateReservationComponent,
    LoginComponent,
    LoginFormComponent,
    RegisterComponent,
    RegisterRegularuserFormComponent,
    RegisterAgencyuserFormComponent,
    AgencyUserProfileComponent,
    RegularUserProfileComponent,
    AgencyTripsListComponent,
  ],
  imports: [
    CommonModule,
    AppsRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    TripService,
    ReservationsService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptor,
      multi: true
    }
  ],
})
export class AppsModule {}
