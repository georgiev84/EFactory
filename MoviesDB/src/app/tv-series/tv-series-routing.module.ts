import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {TvSeriesListComponent} from "./screens/tv-series-list/tv-series-list.component";
import {TvSerieDetailsComponent} from "./screens/tv-serie-details/tv-serie-details.component";


const routes: Routes = [
  {
    path: '',
    component: TvSeriesListComponent
  },
  {
    path:':id',
    component:TvSerieDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TvSeriesRoutingModule { }
