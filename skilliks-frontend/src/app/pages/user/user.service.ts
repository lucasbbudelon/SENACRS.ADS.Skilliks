import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from './user.model';

import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getAll() {
    const url = `${environment.api}/user`;
    return this.httpClient.get<User[]>(url);
  }

  getById(id: string) {
    const url = `${environment.api}/user/${id}`;
    return this.httpClient.get<User>(url);
  }
}
