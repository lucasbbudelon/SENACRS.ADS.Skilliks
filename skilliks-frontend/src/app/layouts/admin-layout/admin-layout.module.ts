import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClipboardModule } from 'ngx-clipboard';
import { NgxMaskModule } from 'ngx-mask';
import { JobInterviewFormComponent } from 'src/app/pages/job-interview/job-interview-form/job-interview-form.component';
import { JobInterviewComponent } from 'src/app/pages/job-interview/job-interview.component';
import { JobInterviewService } from 'src/app/pages/job-interview/job-interview.service';
import { LoginService } from 'src/app/pages/login/login.service';
import { TeamComponent } from 'src/app/pages/team/team.component';
import { AuthInterceptor } from '../../auth/auth.interceptor';
import { ApiFeedbackService } from '../../components/api-feedback/api-feedback.service';
import { ComponentsModule } from '../../components/components.module';
import { JobApplicantFormComponent } from '../../pages/job-applicant/job-applicant-form/job-applicant-form.component';
import { JobApplicantComponent } from '../../pages/job-applicant/job-applicant.component';
import { JobApplicantService } from '../../pages/job-applicant/job-applicant.service';
import { JobFormComponent } from '../../pages/job/job-form/job-form.component';
import { JobComponent } from '../../pages/job/job.component';
import { JobService } from '../../pages/job/job.service';
import { SkillComponent } from '../../pages/skill/skill.component';
import { SkillService } from '../../pages/skill/skill.service';
import { UserFormComponent } from '../../pages/user/user-form/user-form.component';
import { UserHeaderComponent } from '../../pages/user/user-header/user-header.component';
import { UserComponent } from '../../pages/user/user.component';
import { UserService } from '../../pages/user/user.service';
import { AdminLayoutRoutes } from './admin-layout.routing';
import { TeamService } from 'src/app/pages/team/team.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(AdminLayoutRoutes),
    NgxMaskModule.forRoot(),
    NgbModule,
    ClipboardModule,
    ComponentsModule
  ],
  declarations: [
    UserComponent,
    UserHeaderComponent,
    UserFormComponent,
    JobComponent,
    JobFormComponent,
    JobApplicantComponent,
    JobApplicantFormComponent,
    JobInterviewComponent,
    JobInterviewFormComponent,
    SkillComponent,
    TeamComponent
  ],
  providers: [
    ApiFeedbackService,
    UserService,
    JobInterviewService,
    JobApplicantService,
    JobService,
    SkillService,
    TeamService,
    LoginService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ]
})

export class AdminLayoutModule { }
