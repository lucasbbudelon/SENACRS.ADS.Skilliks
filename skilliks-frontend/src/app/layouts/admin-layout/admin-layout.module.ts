import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClipboardModule } from 'ngx-clipboard';
import { NgxMaskModule } from 'ngx-mask';
import { LoginService } from 'src/app/pages/login/login.service';
import { AuthInterceptor } from '../../auth/auth.interceptor';
import { ApiFeedbackService } from '../../components/api-feedback/api-feedback.service';
import { ComponentsModule } from '../../components/components.module';
import { JobFeedBackFormComponent} from '../../pages/job-feedback/job-feedback-form/job-feedback-form.component';
import { JobFeedBackComponent} from '../../pages/job-feedback/job-feedback.component';
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
import { JobFeedBackService } from 'src/app/pages/job-feedback/job-feedback.service';

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
    JobFeedBackComponent,
    JobFeedBackFormComponent,
    JobApplicantComponent,
    JobApplicantFormComponent,
    JobComponent,
    JobFormComponent,
    SkillComponent
  ],
  providers: [
    ApiFeedbackService,
    UserService,
    JobFeedBackService,
    JobApplicantService,
    JobService,
    SkillService,
    LoginService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ]
})

export class AdminLayoutModule { }
