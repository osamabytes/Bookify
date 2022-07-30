import { Injectable } from '@angular/core';
import { Bookshop } from 'src/app/models/Bookshop.model';

@Injectable({
  providedIn: 'root'
})
export class BookshopService {

  constructor() { }

  public AllBookshops(): Bookshop[]{
    let bookshops: Bookshop[] = [
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'ABC BookShop',
        description: 'ABC Bookshop Description',
        address: 'House No.43, Street No.102, Farooq Street, Islampura, Lahore'
      },
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'DEF BookShop',
        description: 'DEF Bookshop Description',
        address: 'House No.42, Street No.102, Farooq Street, Islampura, Lahore'
      }
    ];

    return bookshops;
  }

  public GetBookShop(id: string): Bookshop{
    let bookShop: Bookshop = {
      id: '00000000-0000-0000-0000-000000000000',
      name: 'ABC BookShop',
      description: 'ABC Bookshop Description',
      address: 'House No.43, Street No.102, Farooq Street, Islampura, Lahore'
    };

    return bookShop;
  }
}
