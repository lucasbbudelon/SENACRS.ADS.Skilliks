import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent {

  @Output() value = new EventEmitter<string>();

  constructor() { }

  change(event) {
    this.value.emit(event.target.value);
  }
}
