import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Team } from './team.model';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getAll() {
    const url = `${environment.api}/team`;
    return this.httpClient.get<Team[]>(url);
  }
}
