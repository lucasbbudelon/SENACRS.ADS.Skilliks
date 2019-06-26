import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { User } from '../user/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  user: User;
  form: FormGroup;

  constructor(
    private router: Router
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
    localStorage.setItem('user-logged-in', this.form.controls.login.value);
    this.router.navigate(['/']);
  }

  formIsInvalid() {
    return this.form.status === 'INVALID';
  }
}
