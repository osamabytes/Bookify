import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-auth-side-bar',
  templateUrl: './auth-side-bar.component.html',
  styleUrls: ['./auth-side-bar.component.css']
})
export class AuthSideBarComponent implements OnInit {

  constructor(public activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
  }

}
