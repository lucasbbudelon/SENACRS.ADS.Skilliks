import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/pages/login/login.service';
import { ROUTES } from '../sidebar/sidebar.component';
import { User } from 'src/app/pages/user/user.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  public focus;
  public listTitles: any[];
  public location: Location;

  public userLoggedIn: User;

  constructor(
    location: Location,
    private loginService: LoginService
  ) {
    this.location = location;
  }

  ngOnInit() {
    this.userLoggedIn = this.loginService.getUserLoggedIn();
    this.listTitles = ROUTES.filter(listTitle => listTitle);
  }

  getTitle() {
    let titlee = this.location.prepareExternalUrl(this.location.path());
    if (titlee.charAt(0) === '#') {
      titlee = titlee.slice(2);
    }
    for (let item = 0; item < this.listTitles.length; item++) {
      if (this.listTitles[item].path === titlee) {
        return this.listTitles[item].title;
      }
    }
    return window.location.pathname.substring(1).replace('/', ' # ');
  }

  logout() {
    this.loginService.logout();
  }
}
