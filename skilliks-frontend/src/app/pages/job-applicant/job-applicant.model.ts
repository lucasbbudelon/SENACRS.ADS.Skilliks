import { Job } from '../job/job-applicant.model';
import { User } from '../user/user.model';

export interface JobApplicant {
    job: Job;
    applicant: User;
    salaryClaim: number;
    lastSalary: number;
    ranking: number;
}
