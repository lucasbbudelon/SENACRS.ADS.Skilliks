import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError, finalize, tap } from 'rxjs/operators';
import { ApiFeedbackService } from 'src/app/components/api-feedback/api-feedback.service';
import { User } from '../user.model';
import { UserService } from '../user.service';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { $ } from 'protractor';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {

  public id: string;
  public safeBackgroundUrl: SafeResourceUrl;
  public user: User;
  public editMode: boolean;

  constructor(
    private activatedRoute: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private apiFeedbackService: ApiFeedbackService,
    private userService: UserService
  ) {

  }

  ngOnInit() {
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    this.loadUser();
  }

  getBackgroundUser() {
    return `url(${this.user.background})`;
  }

  private loadUser() {
    this.apiFeedbackService.showLoading();
    this.user = null;
    this.userService.getById(this.id)
      .pipe(
        tap((user) => {
          this.user = user;
          this.safeBackgroundUrl = this.sanitizer.bypassSecurityTrustUrl(user.background);
        }),
        catchError((error) => this.apiFeedbackService.handlerError(error)),
        finalize(() => this.apiFeedbackService.hideLoading())
      )
      .subscribe();
  }
}
