import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GeneralResponse } from 'src/app/interfaces/Response/GeneralResponse.interface';
import { StorageService } from 'src/app/services/Storage.Service/storage.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';
import { UserService } from 'src/app/services/User.Service/user.service';

@Component({
  selector: 'app-auth-side-bar',
  templateUrl: './auth-side-bar.component.html',
  styleUrls: ['./auth-side-bar.component.css']
})
export class AuthSideBarComponent implements OnInit {

  response: GeneralResponse = {
    status: false,
    errors: []
  }

  constructor(public activeRoute: ActivatedRoute, private storage: StorageService, private toastService: ToastService,
     private userService: UserService, private router: Router) { 
  }

  ngOnInit(): void {
    this.userService.CheckLoginStatus()
    .subscribe({
      next: (response: any) => {
        this.response = response;
      },
      error: (err) => {
        this.response = err.error;
        
        this.storage.Delete('token');

        this.response.errors.forEach(element => {
          this.toastService.openToast(2, element, "primary");
        });

        this.router.navigate(['']);
      }
    });
  }

}
