import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { Job } from '../job.model';
import { JobService } from '../job.service';

@Component({
  selector: 'app-job-form',
  templateUrl: './job-form.component.html',
  styleUrls: ['./job-form.component.scss']
})
export class JobFormComponent implements OnInit {

  public job: Job;

  constructor(
    private apiFeedbackService: ApiFeedbackService,
    private activatedRoute: ActivatedRoute,
    private jobService: JobService
  ) { }

  ngOnInit() {
    this.loadJob();
  }

  getSumJobSkillWeight() {
    return this.job.skills
      .map(x => x.weight)
      .reduce((total, weight) => {
        return total + weight;
      });
  }

  private loadJob() {

    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.job = null;

    this.apiFeedbackService.showLoading();

    this.jobService.getById(id)
      .pipe(
        tap(job => this.job = job),
        catchError(error => this.apiFeedbackService.handlerError(error)),
        finalize(() => this.apiFeedbackService.hideLoading())
      )
      .subscribe();
  }
}
