import { Routes } from '@angular/router';
import { JobInterviewFormComponent } from 'src/app/pages/job-interview/job-interview-form/job-interview-form.component';
import { JobInterviewComponent } from 'src/app/pages/job-interview/job-interview.component';
import { TeamComponent } from 'src/app/pages/team/team.component';
import { JobApplicantFormComponent } from '../../pages/job-applicant/job-applicant-form/job-applicant-form.component';
import { JobApplicantComponent } from '../../pages/job-applicant/job-applicant.component';
import { JobFormComponent } from '../../pages/job/job-form/job-form.component';
import { JobComponent } from '../../pages/job/job.component';
import { SkillComponent } from '../../pages/skill/skill.component';
import { UserFormComponent } from '../../pages/user/user-form/user-form.component';
import { UserComponent } from '../../pages/user/user.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'usuarios', component: UserComponent },
    { path: 'usuario/:id', component: UserFormComponent },
    { path: 'candidaturas', component: JobApplicantComponent },
    { path: 'candidatura/:id', component: JobApplicantFormComponent },
    { path: 'vagas', component: JobComponent },
    { path: 'vaga/:id', component: JobFormComponent },
    { path: 'skills', component: SkillComponent },
    { path: 'entrevistas', component: JobInterviewComponent },
    { path: 'entrevista/:id', component: JobInterviewFormComponent },
    { path: 'times', component: TeamComponent },
];
