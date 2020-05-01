import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../shared/shared.module";
import {PeopleRoutingModule} from "./people-routing.module";
import {PeopleDetailComponent} from "./screens/people-detail/people-detail.component";
import {PeopleListItemComponent} from "./screens/people-list-item/people-list-item.component";
import {PeopleListComponent} from "./screens/people-list/people-list.component";
import {TvSeriesModule} from "../tv-series/tv-series.module";



@NgModule({
  declarations: [
    PeopleDetailComponent,
    PeopleListItemComponent,
    PeopleListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    PeopleRoutingModule,
    TvSeriesModule
  ]
})
export class PeopleModule { }
