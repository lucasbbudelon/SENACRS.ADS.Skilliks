import { JobApplicant } from '../job-applicant/job-applicant.model';
import { Job } from '../job/job.model';
import { User } from '../user/user.model';

export interface JobInterview {
    jobFeedBack: JobFeedBack;
    jobApplicant: JobApplicant;
    userTechnical: User;
    userRecruiter: User;
    date: Date;
}

export interface JobFeedBack {
    job: Job;
    applicant: User;
    userTechnical: User;
    technical: string;
    recruiter: string;
    skills: any[];
}
