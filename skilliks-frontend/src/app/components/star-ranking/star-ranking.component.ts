import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-star-ranking',
  templateUrl: './star-ranking.component.html',
  styleUrls: ['./star-ranking.component.scss']
})
export class StarRankingComponent implements OnInit {

  @Input() ranking: number;

  public stars = [];

  constructor() { }

  ngOnInit() {
    for (let i = 0; i < this.ranking; i++) {
      this.stars.push(true);
    }
  }
}
