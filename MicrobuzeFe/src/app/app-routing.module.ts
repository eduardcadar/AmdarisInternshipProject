import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './pages/homepage/homepage.component';
import { LoginAgencyComponent } from './pages/login-agency/login-agency.component';
import { LoginChooseComponent } from './pages/login-choose/login-choose.component';
import { LoginRegularComponent } from './pages/login-regular/login-regular.component';
import { TripsListComponent } from './pages/trips/trips-list/trips-list.component';
import { RegularUserProfileComponent } from './pages/regular-user-profile/regular-user-profile.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { CreateTripFormComponent } from './pages/trips/create-trip-form/create-trip-form.component';

const routes: Routes = [
  {path: '', component: HomepageComponent},
  {path: 'trips', component: TripsListComponent},
  {path: 'trips/create-trip', component: CreateTripFormComponent},
  {path: 'regular-user-profile', component: RegularUserProfileComponent},
  {path: 'login-regular', component: LoginRegularComponent},
  {path: 'login-agency', component: LoginAgencyComponent},
  {path: 'login-choose', component: LoginChooseComponent},
  {path: '**', component: NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
