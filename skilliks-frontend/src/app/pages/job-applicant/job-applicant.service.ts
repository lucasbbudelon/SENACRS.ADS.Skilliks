import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { JobApplicant } from './job-applicant.model';

@Injectable({
  providedIn: 'root'
})
export class JobApplicantService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getAll() {
    const url = `${environment.api}/jobApplicant`;
    return this.httpClient.get<JobApplicant[]>(url);
  }

  getById(id: string) {
    const url = `${environment.api}/jobApplicant/${id}`;
    return this.httpClient.get<JobApplicant>(url);
  }
}
