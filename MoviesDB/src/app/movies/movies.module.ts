import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MoviesListComponent} from "./screens/movies-list/movies-list.component";
import {MoviesFiltersComponent} from "./screens/movies-filters/movies-filters.component";
import {MovieDetailsComponent} from "./screens/movie-details/movie-details.component";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../shared/shared.module";
import {MoviesListItemComponent} from "./screens/movies-list/movies-list-item/movies-list-item.component";
import {MoviesRoutingModule} from "./movies-route.module";



@NgModule({
  declarations: [
    MoviesListComponent,
    MoviesFiltersComponent,
    MoviesListItemComponent,
    MovieDetailsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    MoviesRoutingModule
  ]
})
export class MoviesModule { }
