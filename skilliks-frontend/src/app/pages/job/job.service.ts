import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Job } from './job.model';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getAll() {
    const url = `${environment.api}/job`;
    return this.httpClient.get<Job[]>(url);
  }

  getById(id: string) {
    const url = `${environment.api}/job/${id}`;
    return this.httpClient.get<Job>(url);
  }
}
