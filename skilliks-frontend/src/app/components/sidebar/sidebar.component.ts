import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/pages/login/login.service';
import { UserCategory, UserType } from 'src/app/pages/user/user.model';

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
  userType: UserType[];
  userCategory: UserCategory[];
}

export const ROUTES: RouteInfo[] = [
  {
    path: '/usuarios', title: 'Usuários',
    icon: 'fa-user', class: 'text-primary',
    userType: [UserType.employee],
    userCategory: [UserCategory.humanResources]
  },
  {
    path: '/candidaturas', title: 'Candidaturas',
    icon: 'fa-chalkboard-teacher', class: 'text-primary',
    userType: [UserType.employee, UserType.applicant],
    userCategory: [UserCategory.humanResources, UserCategory.technical]
  },
  {
    path: '/vagas', title: 'Vagas',
    icon: 'fa-user-tie', class: 'text-primary',
    userType: [UserType.employee, UserType.applicant],
    userCategory: [UserCategory.humanResources, UserCategory.technical]
  },
  {
    path: '/skills', title: 'Skills',
    icon: 'fa-laptop-code', class: 'text-primary',
    userType: [UserType.employee],
    userCategory: [UserCategory.humanResources, UserCategory.technical]
  },
  {
    path: '/entrevistas', title: 'Entrevistas',
    icon: 'fa-clipboard', class: 'text-primary',
    userType: [UserType.employee, UserType.applicant],
    userCategory: [UserCategory.humanResources, UserCategory.technical]
  }
  ,
  {
    path: '/times', title: 'Times',
    icon: 'fa-users', class: 'text-primary',
    userType: [UserType.employee],
    userCategory: [UserCategory.humanResources, UserCategory.technical]
  }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;
  public showDocumentation = false;

  constructor(
    private router: Router,
    private loginService: LoginService
  ) { }

  ngOnInit() {
    const userLoggedIn = this.loginService.getUserLoggedIn();
    this.menuItems = ROUTES.filter(menuItem =>
      menuItem.userCategory.indexOf(userLoggedIn.category) !== -1 &&
      menuItem.userType.indexOf(userLoggedIn.type) !== -1
    );
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
    });
  }
}
