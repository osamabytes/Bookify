import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthResponse } from 'src/app/interfaces/Response/AuthResponse.interface';
import { RegisterResponse } from 'src/app/interfaces/Response/RegisterResponse.interface';
import { User } from 'src/app/interfaces/User.interface';
import { UserLogin } from 'src/app/interfaces/UserLogin.interface';
import { StorageService } from '../Storage.Service/storage.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private storage: StorageService) { }

  public Register(body: User){
    return this.http.post("api/users/Register", body);
  }

  public Login(body: UserLogin){
    return this.http.post("api/users/Login", body);
  }

  public CheckLoginStatus(){
    return this.http.get("api/users/UserStatus");
  }
}