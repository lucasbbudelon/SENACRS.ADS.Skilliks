import { Component, OnInit } from '@angular/core';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { Job } from './job.model';
import { JobService } from './job.service';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent implements OnInit {

  private list: Job[];
  public jobs: Job[];

  constructor(
    private jobService: JobService,
    private apiFeedbackService: ApiFeedbackService
  ) { }

  ngOnInit() {
    this.loadList();
  }

  changeSearch(value: string) {
    const valueLowerCase = value.toLocaleLowerCase();
    this.jobs = this.list.filter(x =>
      x.name.toLocaleLowerCase().indexOf(valueLowerCase) !== -1 ||
      x.description.toLocaleLowerCase().indexOf(valueLowerCase) !== -1 ||
      x.remuneration.toString().indexOf(valueLowerCase) !== -1 ||
      x.team.name.toLocaleLowerCase().indexOf(valueLowerCase) !== -1
    );
  }

  private loadList() {
    this.apiFeedbackService.showLoading();
    this.jobService.getAll()
      .pipe(
        tap(jobs => this.list = this.jobs = jobs),
        catchError((error) => this.apiFeedbackService.handlerError(error)),
        finalize(() => this.apiFeedbackService.hideLoading())
      )
      .subscribe();
  }
}
