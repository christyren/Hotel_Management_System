import { AbstractControl, AsyncValidator, ValidationErrors, AsyncValidatorFn, FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ValidatorService {

  constructor() {

  }

  passwordValidator(control: AbstractControl) {
    // {6,100}           - Assert password is between 6 and 100 characters
    // (?=.*[0-9])       - Assert a string has at least one number
    // (?!.*\s)          - Spaces are not allowed
    // tslint:disable-next-line
    if (control.value.match(/^(?=.*\d)(?=.*[a-zA-Z!@#$%^&*])(?!.*\s).{6,100}$/)) {
      return null;
    } else {
      return { invalidPassword: true };
    }
  }

  // passwordMatch(group: FormGroup) {
  //   // console.log('isnide password match');
  //   // console.log(group);
  //   const pass = group.get('password').value;
  //   const confirmPassword = group.get('confirmPassword').value;

  //   return pass === confirmPassword ? null : { passwordNotMatch: true };
  // }


}