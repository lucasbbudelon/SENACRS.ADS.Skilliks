import { Component, OnInit } from '@angular/core';
import { User } from '../user.model';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../user.service';
import { tap, catchError } from 'rxjs/operators';
import { empty } from 'rxjs';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  public user: User;

  constructor(
    private activatedRoute: ActivatedRoute,
    private userService: UserService
  ) { }

  ngOnInit() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    this.loadUser(id);
  }

  getStars(userSkill) {
    const stars = [];
    for (let i = 0; i < userSkill.ranking; i++) {
      stars.push(true);
    }
    return stars;
  }

  private loadUser(id: string) {
    this.user = null;
    this.userService.getById(id)
      .pipe(
        tap(user => this.user = user),
        catchError((error) => {
          alert('Erro ao carregar usuário');
          console.error(error);
          return empty();
        })
      )
      .subscribe();
  }
}
