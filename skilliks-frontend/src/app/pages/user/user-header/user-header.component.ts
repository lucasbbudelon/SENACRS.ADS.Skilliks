import { Component, OnInit, Input } from '@angular/core';
import { User, UserType } from '../user.model';

@Component({
  selector: 'app-user-header',
  templateUrl: './user-header.component.html',
  styleUrls: ['./user-header.component.scss']
})
export class UserHeaderComponent implements OnInit {

  @Input() users: User[];

  public total: number;

  constructor() { }

  ngOnInit() {
  }

  getTotalUsers() {
    return this.users.length;
  }

  getTotalApplicants() {
    return this.users.filter(x => x.type === UserType.applicant).length;
  }

  getPercentageApplicants() {
    const totalUsers = this.getTotalUsers();
    const totalApplicants = this.getTotalApplicants();
    return (totalApplicants / totalUsers);
  }

  getTotalEmployees() {
    return this.users.filter(x => x.type === UserType.employee).length;
  }

  getPercentageEmployees() {
    const totalUsers = this.getTotalUsers();
    const totalEmployees = this.getTotalEmployees();
    return (totalEmployees / totalUsers);
  }

  getTotalInactive() {
    return this.users.filter(x => !x.isEnable).length;
  }

  getPercentageInactive() {
    const totalUsers = this.getTotalUsers();
    const totalInactive = this.getTotalInactive();
    return (totalInactive / totalUsers);
  }
}
