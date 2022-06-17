import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TripsListComponent } from './trips/trips-list/trips-list.component';
import { AboutComponent } from './about/about.component';
import { FullComponent } from './layout/full/full.component';
import { CreateTripComponent } from './trips/create-trip/create-trip.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { IsAgencyGuard } from './guards/is-agency-guard';
import { IsLoggedGuard } from './guards/is-logged-guard';


const routes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      { path: '', redirectTo: 'trips', pathMatch: 'full' },
      { path: 'trips', component: TripsListComponent },
      { path: 'about', component: AboutComponent },
      { path: 'createTrip', component: CreateTripComponent, canActivate: [IsLoggedGuard, IsAgencyGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppsRoutingModule { }
