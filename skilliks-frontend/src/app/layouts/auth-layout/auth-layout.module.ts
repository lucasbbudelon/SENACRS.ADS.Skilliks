import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LoginComponent } from '../../pages/login/login.component';
import { AuthLayoutRoutes } from './auth-layout.routing';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginService } from 'src/app/pages/login/login.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AuthLayoutRoutes),
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    LoginComponent
  ],
  providers: [
    LoginService
  ]
})
export class AuthLayoutModule { }
