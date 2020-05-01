import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {TvSerieDetailsComponent} from "./screens/tv-serie-details/tv-serie-details.component";
import {TvSeriesListComponent} from "./screens/tv-series-list/tv-series-list.component";
import {TvSeriesListItemComponent} from "./screens/tv-series-list/tv-series-list-item/tv-series-list-item.component";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../shared/shared.module";
import {TvSeriesFiltersComponent} from "./screens/tv-series-filters/tv-series-filters.component";
import {TvSeriesRoutingModule} from "./tv-series-routing.module";
import {FilterPipe} from "../pipes/filter/filter.pipe";



@NgModule({
  declarations: [
    TvSerieDetailsComponent,
    TvSeriesListComponent,
    TvSeriesListItemComponent,
    TvSeriesFiltersComponent,
    FilterPipe
  ],
  exports: [
    FilterPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    TvSeriesRoutingModule
  ]
})
export class TvSeriesModule { }
