import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators,ReactiveFormsModule } from '@angular/forms';
import { ValidatorService } from 'src/app/core/services/validator.service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  // email = new FormControl('');
  // all Reactive Controls inherit from AbstractControl class
  signupForm: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder, private validatorService: ValidatorService) {

    // Creating form control instances manually can become repetitive when dealing with multiple forms.
    // The FormBuilder service provides convenient methods for generating controls


    this.signupForm = new FormGroup({
      FirstName: new FormControl(''),
      LastName: new FormControl(''),
      Email: new FormControl(''),
      Password: new FormControl(''),
    });


  }

  // convenience getter for easy access to form fields
  get f() { return this.signupForm.controls; }


  buildForm() {
    this.signupForm = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: [null, {validators: [Validators.required, Validators.email]}],
      Password: ['', [Validators.required, this.validatorService.passwordValidator]]
    });


  }

  ngOnInit() {
    //    console.log(this.email);
    // we can set a value
    // this.email.setValue('test@test.com');
    // console.log(this.signupForm.controls);
    this.buildForm();


  }

  onSubmit() {
    // console.log('submit clicked');
    console.log(this.signupForm);

    this.submitted = true;
    // stop here if form is invalid
    if (this.signupForm.invalid) {
      return;
    }

  }

}
