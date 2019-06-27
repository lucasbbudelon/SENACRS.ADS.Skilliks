import { Job } from '../job/job.model';
import { User } from '../user/user.model';

export interface jobFeedBack {
    job: Job;
    applicant: User;
    userTechnical: User;
    technical: string;
    recruiter: string;
    skills: any[];
}
