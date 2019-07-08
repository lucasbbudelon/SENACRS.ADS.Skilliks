import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-job-level',
  templateUrl: './job-level.component.html',
  styleUrls: ['./job-level.component.scss']
})
export class JobLevelComponent {
  @Input() level: number;
  constructor() { }
}
