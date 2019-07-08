import { Component, OnInit } from '@angular/core';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { User } from './user.model';
import { UserService } from './user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  private list: User[];
  public users: User[];

  constructor(
    private userService: UserService,
    private apiFeedbackService: ApiFeedbackService
  ) { }

  ngOnInit() {
    this.loadList();
  }

  changeSearch(value: string) {
    const valueLowerCase = value.toLocaleLowerCase();
    this.users = this.list.filter(x =>
      x.name.toLocaleLowerCase().indexOf(valueLowerCase) !== -1 ||
      x.email.toLocaleLowerCase().indexOf(valueLowerCase) !== -1
    );
  }

  private loadList() {
    this.apiFeedbackService.showLoading();
    this.userService.getAll()
      .pipe(
        tap(users => this.list = this.users = users),
        catchError((error) => this.apiFeedbackService.handlerError(error)),
        finalize(() => this.apiFeedbackService.hideLoading())
      )
      .subscribe();
  }
}
