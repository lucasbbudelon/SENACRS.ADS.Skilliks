import { Routes } from '@angular/router';
import { JobApplicantComponent } from '../../pages/job-applicant/job-applicant.component';
import { UserComponent } from '../../pages/user/user.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'users', component: UserComponent },
    { path: 'candidaturas', component: JobApplicantComponent },
];
