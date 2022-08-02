import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookInterface } from 'src/app/interfaces/Book.interface';
import { Author } from 'src/app/models/Author.model';
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

  categories: Category[] = [];
  authors: Author[] = [];

  selectedCategoriesId: any;

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
      name: 'author',
      description: ''
    }
  };

  constructor(private route: ActivatedRoute, private router: Router, private bookService: BookService, 
    private authorService: AuthorService, private categoryService: CategoryService) { }

    ngOnInit(): void {
      this.route.paramMap.subscribe({
        next: (params) => {
          const id = params.get('id');

          if(id){
            // Get Book
            this.bookService.GetBook(id)
            .subscribe({
              next: (book) => {
                this.bookInterface.book = book;
              },
              error: (error) => {
                console.log(error);
              }
            });

            // Get Author
            this.authorService.GetBookAuthor(id)
            .subscribe({
              next: (author) => {
                this.bookInterface.author = author;
              },
              error: (error) => {
                console.log(error);
              }
            });

            // Get Categories
            this.categoryService.GetBookCategoires(id)
            .subscribe({
              next: (categories) => {
                this.bookInterface.categories = categories;

                this.selectedCategoriesId = []

                categories.forEach(element => {
                  this.selectedCategoriesId.push(element.id);
                });

                console.log(this.selectedCategoriesId);
              },
              error: (error) => {
                console.log(error);
              }
            });
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
    if(this.bookInterface.book.id !== '' && this.bookInterface.book.id !== '00000000-0000-0000-0000-000000000000'){
      this.bookService.UpdateBook(this.bookInterface)
      .subscribe({
        next: (response) => {
          console.log("Book Updated Successfully");

          this.router.navigate(['', 'auth', 'books']);
        },
        error: (err) => {
          console.log(err);

          if(err.error.hasOwnProperty('errors')){
            var errors = err.error.errors;

            for(var property in errors){
              let errorList = errors[property];

              errorList.forEach((item: any) => {
                console.log(item);
              });
            }
          }

          if(err.status === 400){
            console.log("Server Error");
          }
        }
      });
    }else{
      this.bookService.AddBook(this.bookInterface)
      .subscribe({
        next: (response) => {
          console.log("Book Added Successfully");

          this.router.navigate(['', 'auth', 'books']);
        },
        error: (err) => {
          console.log(err);

          if(err.error.hasOwnProperty('errors')){
            var errors = err.error.errors;

            for(var property in errors){
              let errorList = errors[property];

              errorList.forEach((item: any) => {
                console.log(item);
              });
            }
          }

          if(err.status === 400){
            console.log("Server Error");
          }
        }
      });
    }
  }

}
