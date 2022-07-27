import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email = new FormControl('', [Validators.required, Validators.email]);
  hidePassword: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

  Login(login: NgForm){
  }

  getEmailErrorMessage(){
    if(this.email.hasError('required')){
      return 'Email is Required';
    }

    return this.email.hasError('email') ? 'Not a valid Email': '';
  }

}
