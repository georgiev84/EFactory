import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ButtonsModule} from "ngx-bootstrap/buttons";
import {AlertModule} from "ngx-bootstrap/alert";
import {BsDropdownModule} from "ngx-bootstrap/dropdown";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";



@NgModule({
  declarations: [],
  exports:[
    ButtonsModule,
    AlertModule,
    BsDropdownModule
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonsModule.forRoot(),
    AlertModule.forRoot(),
    BsDropdownModule.forRoot(),
  ]
})
export class SharedModule { }
