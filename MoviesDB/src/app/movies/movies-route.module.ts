import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MoviesListComponent} from "./screens/movies-list/movies-list.component";
import {MovieDetailsComponent} from "./screens/movie-details/movie-details.component";

const routes: Routes = [
  {
    path: '',
    component: MoviesListComponent
  },
  {
    path:':id',
    component:MovieDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MoviesRoutingModule { }
