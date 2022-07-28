import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  year: string = "";
  date: Date = new Date();

  constructor() { }

  ngOnInit(): void {
    this.year = this.date.getFullYear().toString();
  }

}
