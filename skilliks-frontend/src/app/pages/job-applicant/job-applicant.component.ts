import { Component, OnInit } from '@angular/core';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { JobApplicant } from './job-applicant.model';
import { JobApplicantService } from './job-applicant.service';

@Component({
  selector: 'app-job-applicant',
  templateUrl: './job-applicant.component.html',
  styleUrls: ['./job-applicant.component.scss']
})
export class JobApplicantComponent implements OnInit {

  public jobApplicants: JobApplicant[];

  constructor(
    private jobApplicantService: JobApplicantService,
    private apiFeedbackService: ApiFeedbackService
  ) { }

  ngOnInit() {
    this.loadList();
  }

  private loadList() {
    this.apiFeedbackService.showLoading();
    this.jobApplicantService.getAll()
      .pipe(
        tap((jobApplicants) => this.jobApplicants = jobApplicants),
        catchError((error) => this.apiFeedbackService.handlerError(error)),
        finalize(() => this.apiFeedbackService.hideLoading())
      )
      .subscribe();
  }
}
