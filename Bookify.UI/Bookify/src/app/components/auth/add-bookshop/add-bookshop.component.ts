import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Bookshop } from 'src/app/models/Bookshop.model';
import { BookshopService } from 'src/app/services/BookShop.Service/bookshop.service';

@Component({
  selector: 'app-add-bookshop',
  templateUrl: './add-bookshop.component.html',
  styleUrls: ['./add-bookshop.component.css']
})
export class AddBookshopComponent implements OnInit {

  bookShop: Bookshop = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    description: '',
    address: ''
  };

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private bookShopService: BookshopService) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.bookShopService.GetBookShop(id)
          .subscribe({
            next: (bookShop) => {
              this.bookShop = bookShop;
            },
            error: (err) => {
              console.log(err);
            }
          });
        }
      }
    });
  }

  AddBookShop(addBookShopForm: NgForm){
    if(this.bookShop.id !== '' && this.bookShop.id !== '00000000-0000-0000-0000-000000000000'){
      this.bookShopService.UpdateBookShop(this.bookShop)
      .subscribe({
        next: (bookShop) => {
          addBookShopForm.reset();
          console.log("Bookshop Updated Successfully");

          this.router.navigate(['', 'auth', 'bookshops']);
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
      this.bookShopService.AddBookShop(this.bookShop)
      .subscribe({
        next: (bookShop) => {
          addBookShopForm.reset();
          console.log("Bookshop Added Successfully");

          this.router.navigate(['', 'auth', 'bookshops']);
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
