import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { LoginAgencyComponent } from './login/login-agency/login-agency.component';
import { LoginChooseComponent } from './login/login-choose/login-choose.component';
import { LoginRegularComponent } from './login/login-regular/login-regular.component';
import { TripsListComponent } from './trips/trips-list/trips-list.component';
import { RegularUserProfileComponent } from './users/regular-user-profile/regular-user-profile.component';

const routes: Routes = [
  {path: '', component: HomepageComponent},
  {path: 'trips', component: TripsListComponent},
  {path: 'regular-user-profile', component: RegularUserProfileComponent},
  {path: 'login-regular', component: LoginRegularComponent},
  {path: 'login-agency', component: LoginAgencyComponent},
  {path: 'login-choose', component: LoginChooseComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
