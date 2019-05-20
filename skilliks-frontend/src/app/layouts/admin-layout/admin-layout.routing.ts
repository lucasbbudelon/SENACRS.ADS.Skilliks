import { Routes } from '@angular/router';
import { JobApplicantComponent } from '../../pages/job-applicant/job-applicant.component';
import { UserComponent } from '../../pages/user/user.component';
import { UserFormComponent } from '../../pages/user/user-form/user-form.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'usuarios', component: UserComponent },
    { path: 'usuario/:id', component: UserFormComponent },
    { path: 'candidaturas', component: JobApplicantComponent },
];
