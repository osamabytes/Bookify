import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/models/Book.model';
import { BookService } from 'src/app/services/Book.Service/book.service';

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

  constructor(private route: ActivatedRoute, private bookService: BookService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.book = this.bookService.GetBook(id);
        }
      }
    })
  }

  AddBook(addBookForm: NgForm){
    
  }

}
