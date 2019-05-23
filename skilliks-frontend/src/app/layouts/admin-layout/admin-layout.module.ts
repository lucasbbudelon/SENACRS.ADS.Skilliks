import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClipboardModule } from 'ngx-clipboard';
import { ApiFeedbackService } from '../../components/api-feedback/api-feedback.service';
import { JobApplicantFormComponent } from '../../pages/job-applicant/job-applicant-form/job-applicant-form.component';
import { JobApplicantComponent } from '../../pages/job-applicant/job-applicant.component';
import { JobApplicantService } from '../../pages/job-applicant/job-applicant.service';
import { JobFormComponent } from '../../pages/job/job-form/job-form.component';
import { JobComponent } from '../../pages/job/job.component';
import { JobService } from '../../pages/job/job.service';
import { UserFormComponent } from '../../pages/user/user-form/user-form.component';
import { UserHeaderComponent } from '../../pages/user/user-header/user-header.component';
import { UserComponent } from '../../pages/user/user.component';
import { UserService } from '../../pages/user/user.service';
import { AdminLayoutRoutes } from './admin-layout.routing';
import { ComponentsModule } from '../../components/components.module';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule,
    ComponentsModule
  ],
  declarations: [
    UserComponent,
    UserHeaderComponent,
    UserFormComponent,
    JobApplicantComponent,
    JobApplicantFormComponent,
    JobComponent,
    JobFormComponent
  ],
  providers: [
    ApiFeedbackService,
    UserService,
    JobApplicantService,
    JobService
  ]
})

export class AdminLayoutModule { }
