import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TripsListComponent } from './pages/trips-list/trips-list.component';
import { RegularUserProfileComponent } from './pages/regular-user-profile/regular-user-profile.component';
import { NavbarComponent } from './pages/navbar/navbar.component';
import { LoginRegularComponent } from './pages/login-regular/login-regular.component';
import { LoginAgencyComponent } from './pages/login-agency/login-agency.component';
import { LoginChooseComponent } from './pages/login-choose/login-choose.component';
import { HomepageComponent } from './pages/homepage/homepage.component';

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
