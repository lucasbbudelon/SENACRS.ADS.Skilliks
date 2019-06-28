import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { jobFeedBack } from './job-feedback.model';

@Injectable({
  providedIn: 'root'
})
export class JobFeedBackService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getAll() {
    const url = `${environment.api}/jobFeedBack`;
    return this.httpClient.get<jobFeedBack[]>(url);
  }

  getById(id: string) {
    const url = `${environment.api}/jobFeedBack/${id}`;
    return this.httpClient.get<jobFeedBack>(url);
  }
}
