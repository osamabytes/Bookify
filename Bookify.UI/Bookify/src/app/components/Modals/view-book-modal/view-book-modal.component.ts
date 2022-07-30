import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Book } from 'src/app/models/Book.model';

@Component({
  selector: 'app-view-book-modal',
  templateUrl: './view-book-modal.component.html',
  styleUrls: ['./view-book-modal.component.css']
})
export class ViewBookModalComponent implements OnInit {

  book: Book = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    isbn: '',
    description: '',
    active: false
  };

  constructor(private dialogRef: MatDialogRef<ViewBookModalComponent>, @Inject(MAT_DIALOG_DATA) data: any) { 
    this.book = data;
  }

  ngOnInit(): void {
  }

}
