import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}

export const ROUTES: RouteInfo[] = [
  { path: '/usuarios', title: 'Usuários', icon: 'fa-users', class: 'text-primary' },
  { path: '/candidaturas', title: 'Candidaturas', icon: 'fa-chalkboard-teacher', class: 'text-primary' },
  { path: '/vagas', title: 'Vagas', icon: 'fa-user-ti', class: 'text-primary' }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;

  constructor(private router: Router) { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
    });
  }
}
