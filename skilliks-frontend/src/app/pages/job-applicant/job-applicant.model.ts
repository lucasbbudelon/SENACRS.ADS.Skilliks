import { Job } from '../job/job.model';
import { User } from '../user/user.model';

export interface JobApplicant {
    job: Job;
    applicant: User;
    salaryClaim: number;
    score: number;
    star: boolean;
}
