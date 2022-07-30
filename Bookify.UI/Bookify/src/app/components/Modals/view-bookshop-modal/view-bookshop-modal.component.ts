import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Bookshop } from 'src/app/models/Bookshop.model';

@Component({
  selector: 'app-view-bookshop-modal',
  templateUrl: './view-bookshop-modal.component.html',
  styleUrls: ['./view-bookshop-modal.component.css']
})
export class ViewBookshopModalComponent implements OnInit {

  bookShop: Bookshop = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    description: '',
    address: ''
  };

  constructor(private dialogRef: MatDialogRef<ViewBookshopModalComponent>, @Inject(MAT_DIALOG_DATA) data: any) { 
    this.bookShop = data;
  }

  ngOnInit(): void {
  }

}
