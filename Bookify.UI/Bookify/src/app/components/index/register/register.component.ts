import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/interfaces/User.interface';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  hidePassword: Boolean = true;
  hideConfirmPassword: Boolean = true;

  user: User = {
    id: "00000000-0000-0000-0000-000000000000",
    firstname: '',
    lastname: '',
    age: 0,
    email: '',
    password: '',
    confirmpassword: '',
    addressline1: '',
    addressline2: '',
    state: '',
    city: '',
    country: '',
    zipcode: '',
    cardowner: '',
    cardnumber: '',
    cvv: 0,
    expiration: new Date()
  };

  generalFormGroup = this._formBuilder.group({
    firstname: ['', Validators.required],
    lastname: [''],
    age: [''],
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
    confirmpassword: ['', Validators.required]
  });

  addressFormGroup = this._formBuilder.group({
    addressline1: ['', Validators.required],
    addressline2: [''],
    state: ['', Validators.required],
    city: ['', Validators.required],
    country: ['', Validators.required],
    zipcode: ['', Validators.required],
  });

  creditCardFormGroup = this._formBuilder.group({
    owner: ['', Validators.required],
    ccn: ['', Validators.required],
    cvv: ['', Validators.required],
    expiry: ['', Validators.required]
  });

  userInfoFormGroup = this._formBuilder.group({
  });

  constructor(private _formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {
  }

  GetEmailError(){
    let emailInp = this.generalFormGroup.controls.email;
    return emailInp.hasError('email') ? 'Not a valid Email': '';
  }

  Submit(){
    console.log(this.user);

    this.router.navigate(['confirm']);
  }

}
