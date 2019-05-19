import { Component, OnInit } from '@angular/core';
import { empty } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
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
    private jobApplicantService: JobApplicantService
  ) { }

  ngOnInit() {
    this.jobApplicantService.getAll()
      .pipe(
        tap((jobApplicants) => this.jobApplicants = jobApplicants),
        catchError((error) => {
          console.log(error);
          return empty();
        })
      )
      .subscribe();
  }
}
