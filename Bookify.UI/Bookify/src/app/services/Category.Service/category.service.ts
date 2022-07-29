import { Injectable } from '@angular/core';
import { Category } from 'src/app/models/Category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor() { }

  public AllCategory(): Category[]{
    let categories: Category[] = [
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Horror'
      },
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Technology'
      }
    ];

    return categories;
  }
}
