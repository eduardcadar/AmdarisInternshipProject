import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppsRoutingModule } from './apps-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppsComponent } from './apps.component';
import { TripsListComponent } from './trips/trips-list/trips-list.component';
import { AboutComponent } from './about/about.component';
import { BlogDetailComponent } from './blog/blog-detail/blog-detail.component';

import { ServiceblogService } from './blog/blog-service.service';
import { RelayOnComponent } from './about/About-Components/relay-on/relay-on.component';
import { TopContentComponent } from './about/About-Components/top-content/top-content.component';

import { FullComponent } from './layout/full/full.component';

import { BannerComponent } from './shared/banner/banner.component';
import { BannerNavigationComponent } from './shared/banner-navigation/banner-navigation.component';
import { FooterComponent } from './shared/footer/footer.component';
import { TripService } from './services/trip-service';
import { SearchTripComponent } from './trips/search-trip/search-trip.component';
import { ReservationsService } from './services/reservations-service';
import { ReservationsListComponent } from './about/reservations/reservations-list/reservations-list.component';
import { ReserveButtonComponent } from './trips/reserve-button/reserve-button.component';
import { CreateTripComponent } from './trips/create-trip/create-trip.component';
import { UpdateReservationComponent } from './about/reservations/update-reservation/update-reservation.component';
import { LoginComponent } from './account/login/login.component';
import { LoginFormComponent } from './account/login/login-form/login-form.component';
import { RegisterComponent } from './account/register/register.component';
import { RegisterRegularuserFormComponent } from './account/register/register-regularuser-form/register-regularuser-form.component';
import { RegisterAgencyuserFormComponent } from './account/register/register-agencyuser-form/register-agencyuser-form.component';

@NgModule({
  declarations: [
    AppsComponent,
    TripsListComponent,
    AboutComponent,
    BlogDetailComponent,
    RelayOnComponent,
    TopContentComponent,
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
    ServiceblogService,
    TripService,
    ReservationsService
  ],
})
export class AppsModule {}
