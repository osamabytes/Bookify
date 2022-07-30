import { Injectable } from '@angular/core';
import { Author } from 'src/app/models/Author.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  constructor() { }

  public AllAuthors(): Author[]{
    let authors: Author[] = [
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Osama Ahmad',
        description: 'Author Specialized for writing tech books'
      },
      {
        id: '00000000-0000-0000-0000-000000000000',
        name: 'Ali Raza',
        description: 'Author Specialized for writing life physicology books'
      }
    ];

    return authors;
  }

  public GetAuthor(id: string): Author{
    let author: Author = {
      id: '00000000-0000-0000-0000-000000000000',
      name: 'Osama Ahmad',
      description: 'Author Specialized for writing tech books'
    };

    return author;
  }
}
