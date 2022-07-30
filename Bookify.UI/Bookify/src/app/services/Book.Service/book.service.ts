import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from 'src/app/models/Book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor() { }

  public AllBooks(): Book[]{
    let books: Book[] = [
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Harry Potter',
        isbn: '6145155415',
        description: 'This is a Harry Potter Book',
        active: true
      },
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Physics Book',
        isbn: '6145155415',
        description: 'This is a Basic Physics Book',
        active: false
      }
    ];

    return books;
  }

  public GetBook(id: string): Book{
    let book: Book = {
      id: '00000000-0000-0000-0000-000000000000',
      name: 'Physics Book',
      isbn: '6145155415',
      description: 'This is a Basic Physics Book',
      active: false 
    };

    return book;
  }
}
