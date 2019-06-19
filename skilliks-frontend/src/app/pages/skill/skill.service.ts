import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Skill } from './skill.model';

@Injectable({
  providedIn: 'root'
})
export class SkillService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getAll() {
    const url = `${environment.api}/skill`;
    return this.httpClient.get<Skill[]>(url);
  }
}
