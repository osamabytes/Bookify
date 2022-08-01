import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BookInterface } from 'src/app/interfaces/Book.interface';
import { Author } from 'src/app/models/Author.model';
import { Book } from 'src/app/models/Book.model';
import { Category } from 'src/app/models/Category.model';
import { AuthorService } from 'src/app/services/Author.Service/author.service';
import { BookService } from 'src/app/services/Book.Service/book.service';
import { CategoryService } from 'src/app/services/Category.Service/category.service';

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

  categories: Category[] = [];
  authors: Author[] = [];

  bookInterface: BookInterface = {
    book: {
      id: '00000000-0000-0000-0000-000000000000',
      name: '',
      isbn: '',
      description: '',
      active: false
    },
    categories: [],
    author: {
      id: '00000000-0000-0000-0000-000000000000',
      name: '',
      description: ''
    }
  };

  constructor(private route: ActivatedRoute, private bookService: BookService, 
    private authorService: AuthorService, private categoryService: CategoryService) { }

    ngOnInit(): void {
      this.route.paramMap.subscribe({
        next: (params) => {
          const id = params.get('id');

          if(id){
            this.book = this.bookService.GetBook(id);
          }
        }
      });

      this.authorService.AllAuthors()
      .subscribe({
        next: (authors) => {
          this.authors = authors;
        },
        error: (err) => {
          console.log(err);
        }
      });

      this.categoryService.AllCategory()
      .subscribe({
        next: (categories) => {
          this.categories = categories;
        },
        error: (err) => {
          console.log(err);
        }
      });
  }

  OnAuthorSelection(AuthorId: string){
    this.bookInterface.author.id = AuthorId;
  }

  OnCategorySelection(CategoryId: string){
    let categoriesList = this.bookInterface.categories;

    const isFound = categoriesList.some(element => {
      if(element.id === CategoryId){
        return true;
      }

      return false;
    });

    if(!isFound){
      categoriesList.push({
        id: CategoryId,
        name: ''
      });
    }else{
      for(var i=0; i < categoriesList.length; i++){
        if(categoriesList[i].id === CategoryId){
          categoriesList.splice(i, 1);
        }
      }
    }
  }

  AddBook(addBookForm: NgForm){
    
  }

}
