import { Component } from '@angular/core';
import { ApiFeedbackService } from './api-feedback.service';

@Component({
  selector: 'app-api-feedback',
  templateUrl: './api-feedback.component.html',
  styleUrls: ['./api-feedback.component.scss']
})
export class ApiFeedbackComponent {

  constructor() { }

  isLoading() {
    return ApiFeedbackService.loading;
  }

  isInfo() {
    return ApiFeedbackService.infoMessage;
  }

  isSuccess() {
    return ApiFeedbackService.successMessage;
  }

  isAlert() {
    return ApiFeedbackService.alertMessage;
  }

  isError() {
    return ApiFeedbackService.errorMessage;
  }
}
