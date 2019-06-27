import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { jobFeedBack } from '../job-feedback.model';
import { JobFeedBackService } from '../job-feedback.service';

@Component({
  selector: 'app-job-feedback-form',
  templateUrl: './job-feedback-form.component.html',
  styleUrls: ['./job-feedback-form.component.scss']
})
export class JobFeedBackFormComponent implements OnInit {

  public jobFeedBack: jobFeedBack;

  constructor(
    private apiFeedbackService: ApiFeedbackService,
    private activatedRoute: ActivatedRoute,
    private jobFeedBackService: JobFeedBackService
  ) { }

  ngOnInit(){
    this.loadJobFeedBack();
  }

  private loadJobFeedBack(){
    
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.jobFeedBack = null;
    this.apiFeedbackService.showLoading();

    this.jobFeedBackService.getById(id)
    .pipe(
      tap((jobFeedBack => this.jobFeedBack = jobFeedBack)),
      catchError(error => this.apiFeedbackService.handlerError(error)),
      finalize(() => this.apiFeedbackService.hideLoading())
    )
    .subscribe();
  }
}
