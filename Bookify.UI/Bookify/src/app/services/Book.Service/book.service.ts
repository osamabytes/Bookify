import { Injectable } from '@angular/core';
import { Book } from 'src/app/models/Book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor() { }

  public GetBookColumn(){
    return [
      'Name',
      'ISBN',
      'Description',
      'Activation',
      'Action'
    ];
  }

  public AllBooks(){
    let books: Book[] = [
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Harry Potter',
        isbn: '6145155415',
        description: 'This is a Harry Potter Book',
        isActived: true
      },
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Physics Book',
        isbn: '6145155415',
        description: 'This is a Basic Physics Book',
        isActived: true
      }
    ];

    return books;
  }
}
