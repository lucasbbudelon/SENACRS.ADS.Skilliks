import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { JobApplicant } from '../job-applicant.model';
import { JobApplicantService } from '../job-applicant.service';

@Component({
  selector: 'app-job-applicant-form',
  templateUrl: './job-applicant-form.component.html',
  styleUrls: ['./job-applicant-form.component.scss']
})
export class JobApplicantFormComponent implements OnInit {

  public jobApplicant: JobApplicant;

  constructor(
    private apiFeedbackService: ApiFeedbackService,
    private activatedRoute: ActivatedRoute,
    private jobApplicantService: JobApplicantService
  ) { }

  ngOnInit() {
    this.loadJobApplicant();
  }

  private loadJobApplicant() {

    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.jobApplicant = null;

    this.apiFeedbackService.showLoading();

    this.jobApplicantService.getById(id)
      .pipe(
        tap((jobApplicant) => {
          this.jobApplicant = jobApplicant;
          this.jobApplicant.job.skills.forEach(jobSkill => {
            const skill = this.jobApplicant.applicant.skills.find(x => x.idSkill === jobSkill.idSkill);
            jobSkill.rankingApplicant = skill ? skill.ranking : 0;
          });
        }),
        catchError(error => this.apiFeedbackService.handlerError(error)),
        finalize(() => this.apiFeedbackService.hideLoading())
      )
      .subscribe();
  }
}
