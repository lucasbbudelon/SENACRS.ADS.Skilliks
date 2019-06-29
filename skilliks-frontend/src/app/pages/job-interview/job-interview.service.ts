import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { JobInterview } from './job-interview.model';

@Injectable({
  providedIn: 'root'
})
export class JobInterviewService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getAll() {
    const url = `${environment.api}/jobInterview`;
    return this.httpClient.get<JobInterview[]>(url);
  }

  getById(id: string) {
    const url = `${environment.api}/jobInterview/${id}`;
    return this.httpClient.get<JobInterview>(url);
  }
}
