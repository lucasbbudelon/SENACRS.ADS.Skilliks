import { Injectable } from '@angular/core';
import { BehaviorSubject, empty, of } from 'rxjs';
import { flatMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiFeedbackService {

  static loading: boolean;

  static infoMessage: string;
  static successMessage: string;
  static alertMessage: string;
  static errorMessage: string;

  constructor() { }

  public showLoading() {
    ApiFeedbackService.loading = true;
  }

  public hideLoading() {
    ApiFeedbackService.loading = false;
  }

  public showSuccessMessage(message: string) {
    ApiFeedbackService.successMessage = message;
  }

  public showInfoMessage(message: string) {
    ApiFeedbackService.infoMessage = message;
  }

  public showAlertMessage(message: string) {
    ApiFeedbackService.alertMessage = message;
  }

  public showErrorMessage(message: string) {
    ApiFeedbackService.errorMessage = message;
  }

  public handlerError(error) {
    console.log(error);
    this.showErrorMessage('Ocorreu um erro na comunicação com a API.');
    return of({});
  }
}
