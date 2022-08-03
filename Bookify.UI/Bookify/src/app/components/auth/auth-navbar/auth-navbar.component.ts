import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/services/Storage.Service/storage.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';

@Component({
  selector: 'app-auth-navbar',
  templateUrl: './auth-navbar.component.html',
  styleUrls: ['./auth-navbar.component.css']
})
export class AuthNavbarComponent implements OnInit {

  constructor(private storageService: StorageService, private toastService: ToastService, private router: Router) { }

  ngOnInit(): void {
  }

  Logout(){
    this.storageService.Delete('token');
    this.toastService.openToast(['Logged out Successfully'], "primary");
    this.router.navigate(['']);
  }

}
