import { Component, OnInit } from '@angular/core';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { JobInterview } from './job-interview.model';
import { JobInterviewService } from './job-interview.service';

@Component({
  selector: 'app-job-interview',
  templateUrl: './job-interview.component.html',
  styleUrls: ['./job-interview.component.scss']
})
export class JobInterviewComponent implements OnInit {

  public jobInterviews: JobInterview[];

  constructor(
    private jobInterviewService: JobInterviewService,
    private apiFeedbackService: ApiFeedbackService
  ) { }

  ngOnInit() {
    this.loadList();
  }

  private loadList() {
    this.apiFeedbackService.showLoading();
    this.jobInterviewService.getAll()
      .pipe(
        tap((jobInterviews) => this.jobInterviews = jobInterviews),
        catchError((error) => this.apiFeedbackService.handlerError(error)),
        finalize(() => this.apiFeedbackService.hideLoading())
      )
      .subscribe();
  }
}
