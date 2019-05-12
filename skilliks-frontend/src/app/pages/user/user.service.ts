import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getAll() {
    const url = 'https://localhost:44345/api/user';
    return this.httpClient.get<User[]>(url);
  }
}
