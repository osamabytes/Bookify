import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { User } from 'src/app/models/User.models';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user: User = {
    id: "00000000-0000-0000-0000-000000000000",
    firstname: '',
    lastname: '',
    age: 0,
    email: '',
    password: '',
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
  }

  generalFormGroup = this._formBuilder.group({
    firstname: ['', Validators.required],
    lastname: [''],
    age: [''],
    email: ['', Validators.required],
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

  constructor(private _formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  Submit(){
    console.log(this.user);
  }

}
