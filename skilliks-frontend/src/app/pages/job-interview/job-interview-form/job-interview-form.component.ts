import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { JobInterview } from '../job-interview.model';
import { JobInterviewService } from '../job-interview.service';

@Component({
  selector: 'app-job-interview-form',
  templateUrl: './job-interview-form.component.html',
  styleUrls: ['./job-interview-form.component.scss']
})
export class JobInterviewFormComponent implements OnInit {

  public jobInterview: JobInterview;

  constructor(
    private apiFeedbackService: ApiFeedbackService,
    private activatedRoute: ActivatedRoute,
    private jobInterviewService: JobInterviewService
  ) { }

  ngOnInit() {
    this.loadJobFeedBack();
  }

  private loadJobFeedBack() {

    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.jobInterview = null;
    this.apiFeedbackService.showLoading();

    this.jobInterviewService.getById(id)
      .pipe(
        tap((jobInterview => this.jobInterview = jobInterview)),
        catchError(error => this.apiFeedbackService.handlerError(error)),
        finalize(() => this.apiFeedbackService.hideLoading())
      )
      .subscribe();
  }
}
