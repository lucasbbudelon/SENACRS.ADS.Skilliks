import { Component, OnInit } from '@angular/core';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { jobFeedBack } from './job-feedback.model';
import { JobFeedBackService } from './job-feedback.service';

@Component({
  selector: 'app-job-feedback',
  templateUrl: './job-feedback.component.html',
  styleUrls: ['./job-feedback.component.scss']
})
export class JobFeedBackComponent implements OnInit {

  public jobFeedBacks: jobFeedBack[];

  constructor(
    private jobFeedBackService: JobFeedBackService,
    private apiFeedbackService: ApiFeedbackService
  ) { }

  ngOnInit() {
    this.loadList();
  }

  private loadList() {
    this.apiFeedbackService.showLoading();
    this.jobFeedBackService.getAll()
    .pipe(
      tap((jobFeedBacks) => this.jobFeedBacks = jobFeedBacks),
      catchError((error) => this.apiFeedbackService.handlerError(error)),
      finalize(() => this.apiFeedbackService.hideLoading())
    )
    .subscribe();
  }
}
