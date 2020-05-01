import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './screens/home/home.component';
import { MoviesListComponent } from './movies/screens/movies-list/movies-list.component';
import { TvSeriesListComponent } from './tv-series/screens/tv-series-list/tv-series-list.component';
import { PeopleListComponent } from './people/screens/people-list/people-list.component';
import { MovieDetailsComponent } from './movies/screens/movie-details/movie-details.component';
import { TvSerieDetailsComponent } from './tv-series/screens/tv-serie-details/tv-serie-details.component';
import { PeopleDetailComponent } from './people/screens/people-detail/people-detail.component';
import { AuthComponent } from './screens/auth/auth.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'auth',
    component: AuthComponent,
  },
  {
    path: 'movies',
    loadChildren: () => import('./movies/movies.module').then(module=>module.MoviesModule)
  },
  {
    path: 'tv-shows',
    loadChildren: () => import('./tv-series/tv-series.module').then(module=>module.TvSeriesModule)
  },
  {
    path: 'people',
    loadChildren: () => import('./people/people.module').then(module=>module.PeopleModule)
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
