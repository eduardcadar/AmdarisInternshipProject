import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TripsListComponent } from './trips/trips-list/trips-list.component';
import { RegularUserProfileComponent } from './users/regular-user-profile/regular-user-profile.component';
import { NavbarComponent } from './menu/navbar/navbar.component';
import { LoginRegularComponent } from './login/login-regular/login-regular.component';
import { LoginAgencyComponent } from './login/login-agency/login-agency.component';
import { LoginChooseComponent } from './login/login-choose/login-choose.component';
import { HomepageComponent } from './homepage/homepage.component';

@NgModule({
  declarations: [
    AppComponent,
    TripsListComponent,
    RegularUserProfileComponent,
    LoginRegularComponent,
    NavbarComponent,
    LoginAgencyComponent,
    LoginChooseComponent,
    HomepageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
