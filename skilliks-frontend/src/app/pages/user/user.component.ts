import { Component, OnInit } from '@angular/core';
import { catchError, tap } from 'rxjs/operators';

import { User } from './user.model';
import { UserService } from './user.service';
import { empty } from 'rxjs';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  public users: User[];

  constructor(
    private userService: UserService
  ) { }

  ngOnInit() {
    this.userService.getAll()
      .pipe(
        tap((users) => this.users = users),
        catchError((error) => {
          console.log(error);
          return empty();
        })
      )
      .subscribe();
  }
}
