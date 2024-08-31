import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {UserAuthModule} from './user-auth/user-auth.module'

import { AppComponent } from './app.component';
import { SignupComponent   } from './signup/signup.component';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule,
    UserAuthModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
