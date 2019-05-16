import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClipboardModule } from 'ngx-clipboard';
import { JobApplicantComponent } from '../../pages/job-applicant/job-applicant.component';
import { UserFormComponent } from '../../pages/user/user-form/user-form.component';
import { UserHeaderComponent } from '../../pages/user/user-header/user-header.component';
import { UserComponent } from '../../pages/user/user.component';
import { UserService } from '../../pages/user/user.service';
import { AdminLayoutRoutes } from './admin-layout.routing';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule
  ],
  declarations: [
    UserComponent,
    UserHeaderComponent,
    UserFormComponent,
    JobApplicantComponent
  ],
  providers: [
    UserService
  ]
})

export class AdminLayoutModule { }
