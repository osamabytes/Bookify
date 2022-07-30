import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private activatedRoute: ActivatedRoute, private bookShopService: BookshopService) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          var bookShop = this.bookShopService.GetBookShop(id);

          this.bookShop = bookShop;
        }
      }
    });
  }

  AddBookShop(addBookShopForm: NgForm){
  }

}
