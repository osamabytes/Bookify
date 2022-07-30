import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Book } from 'src/app/models/Book.model';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  book: Book = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    isbn: '',
    description: '',
    active: false
  };

  constructor() { }

  ngOnInit(): void {
  }

  AddBook(addBookForm: NgForm){
    
  }

}
