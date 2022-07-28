import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  year: string = "";
  date: Date = new Date();

  constructor() {
  }

  ngOnInit(): void {
    this.year = this.date.getFullYear().toString();
  }

}
