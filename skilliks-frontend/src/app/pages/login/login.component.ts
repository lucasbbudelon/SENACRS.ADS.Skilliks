import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { User } from '../user/user.model';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  public user: User;
  public form: FormGroup;
  public invalidCredentials: boolean;

  constructor(
    private router: Router,
    private loginService: LoginService
  ) {
    this.form = new FormGroup({
      'login': new FormControl(null,
        [
          Validators.required,
          Validators.email
        ])
    });
  }

  ngOnInit() {

  }

  ngOnDestroy() {
  }

  submit() {
    this.loginService.login(this.form.controls.login.value)
      .pipe(
        tap((ok) => {
          this.invalidCredentials = !ok;
          if (ok) { this.redirectToDefaultPage(); }
        })
      )
      .subscribe();
  }

  formIsInvalid() {
    return this.form.status === 'INVALID';
  }

  private redirectToDefaultPage() {
    this.router.navigate(['/']);
  }
}
