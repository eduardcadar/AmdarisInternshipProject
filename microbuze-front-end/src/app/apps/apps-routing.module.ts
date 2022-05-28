import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TripsListComponent } from './trips/trips-list/trips-list.component';
import { AboutComponent } from './about/about.component';
import { BlogDetailComponent } from './blog/blog-detail/blog-detail.component';
import { FullComponent } from './layout/full/full.component';
import { CreateTripComponent } from './trips/create-trip/create-trip.component';
import { LoginComponent } from './account/login/login.component';


const routes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      { path: '', redirectTo: 'trips', pathMatch: 'full' },
      { path: 'trips', component: TripsListComponent },
      { path: 'blogDetail/:id', component: BlogDetailComponent },
      { path: 'about', component: AboutComponent },
      { path: 'createTrip', component: CreateTripComponent },
      { path: 'login', component: LoginComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppsRoutingModule { }
