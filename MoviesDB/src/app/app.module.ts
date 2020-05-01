import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './screens/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ImgFallbackDirective } from './directives/img-fallback/img-fallback.directive';
import { AngularFireModule } from '@angular/fire';
import { environment } from 'src/environments/environment';
import { AuthComponent } from './screens/auth/auth.component';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { AlertModule } from 'ngx-bootstrap/alert';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { DropdownComponent } from './dropdown/dropdown/dropdown.component';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';
import {StoreModule} from "@ngrx/store";
import * as movieState from './store';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ImgFallbackDirective,
    AuthComponent,
    DropdownComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    AngularFireModule.initializeApp(environment.firebase),
    ButtonsModule.forRoot(),
    AlertModule.forRoot(),
    PopoverModule.forRoot(),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: environment.production }),
    EffectsModule.forRoot([]),
    StoreModule.forFeature(movieState.movieStateFeatureKey, movieState.reducers),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
